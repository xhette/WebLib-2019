using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLib.Models.Repositories.CompositeModels.Issues;

namespace WebLib.Models.Repositories
{
    public class IssueRepository
    {
        private static string issueViewQuery = String.Format
            ("select * from (Authors join (Books join (Issues join Readers on reader = reader_card) on book = book_id) on author = author_id) ");

        public static IssueModel DataToModel(DataRow row)
        {
            IssueModel issue = new IssueModel
            {
                Id = row.Field<int>("issue_id"),
                BookId = row.Field<int>("book"),
                ReaderId = row.Field<int>("reader"),
                OccupiedDate = row.Field<DateTime>("issue_date"),
                ReturnedDate = row.Field<DateTime>("return_date"),
                IsReturned = row.Field<bool>("returned")
            };

            return issue;
        }

        public static IssueViewModel DataToViewModel (DataRow row)
        {
            IssueViewModel issue = new IssueViewModel
            {
                Author = AuthorRepository.DataToModel(row),
                Book = BookRepository.DataToModel(row),
                Reader = ReaderRepository.DataToModel(row),
                Issue = DataToModel(row)
            };

            return issue;
        }

        public static List<IssueViewModel> IssueList(string query)
        {
            List<IssueViewModel> issues = new List<IssueViewModel>();
            DataSet data = DbContext.DbConnection(query);
            foreach (DataRow row in data.Tables[0].Rows)
                issues.Add(DataToViewModel(row));
            return issues;
        }

        public static List<IssueViewModel> SelectAll()
        {
            return IssueList(issueViewQuery);
        }

        public static List<IssueViewModel> SelectByReader(int id)
        {
            string query = String.Format(issueViewQuery + "where reader_id = {0}", id);
            return IssueList(query);
        }

        public static List<IssueViewModel> SelectExpired()
        {
            string query = String.Format(issueViewQuery + "(issue_date <= DATEADD(DAY, -14, SYSDATETIME())) and (return_date IS NULL)");
            return IssueList(query);
        }

        public static IssueEditModel Add()
        {
            IssueEditModel model = new IssueEditModel
            {
                Issue = new IssueModel()
            };

            model.Readers = new SelectList(ReaderRepository.SelectAll(), "Id", "ConcatReaderName");
            model.Authors = new SelectList(AuthorRepository.SelectAll(), "Id", "ConcatName");
            model.Books = new SelectList(BookRepository.AllBooks(), "Id", "Title");

            return model;
        }

        public static void Add(IssueEditModel model)
        {
            string query = String.Format("insert into Issues (book, reader, issue_date) values ({0}, {1}, {2})",
                model.SelectedBook, model.SelectedReader, model.Issue.OccupiedDate);
            DataSet data = DbContext.DbConnection(query);
        }

        public static void Delete(int id)
        {
            string query = String.Format("delete from Issues where issue_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);
        }

        public static IssueViewModel Edit (int id)
        {
            string query = String.Format(issueViewQuery + "where issue_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);
            IssueViewModel model = DataToViewModel(data.Tables[0].Rows[0]);

            return model;
        }

        public static void Edit (IssueEditModel model)
        {
            string query = String.Format("update table Issues set return_date = {0} where issue_id = {1}", 
                model.Issue.ReturnedDate, model.Issue.Id);
            DataSet data = DbContext.DbConnection(query);
        }

    }
}
