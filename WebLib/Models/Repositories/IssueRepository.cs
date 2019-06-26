using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            IssueModel issue;
            try
            {
                issue = new IssueModel
                {
                    Id = row.Field<int>("issue_id"),
                    BookId = row.Field<int>("book"),
                    ReaderId = row.Field<int>("reader"),
                    OccupiedDate = row.Field<DateTime>("issue_date"),
                    ReturnedDate = row.Field<DateTime>("return_date")
                };
            } catch (Exception ex)
            {
                issue = new IssueModel
                {
                    Id = row.Field<int>("issue_id"),
                    BookId = row.Field<int>("book"),
                    ReaderId = row.Field<int>("reader"),
                    OccupiedDate = row.Field<DateTime>("issue_date"),
                    ReturnedDate = null
                };
            }

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
            string query = String.Format(issueViewQuery + "where (issue_date <= DATEADD(DAY, -14, SYSDATETIME())) and (return_date IS NULL)");
            return IssueList(query);
        }

        public static IssueAddModel Add(int id)
        {
            string bookquery = String.Format("select * from Books join Authors on author = author_id where book_id = {0}", id);
            DataSet data = DbContext.DbConnection(bookquery);
            IssueAddModel model = new IssueAddModel
            {
                Issue = new IssueModel {
                    OccupiedDate = DateTime.Now
                },
                Book = (BookRepository.DataToModel(data.Tables[0].Rows[0])),
                Author = (AuthorRepository.DataToModel(data.Tables[0].Rows[0]))
            };

            model.Readers = new SelectList(ReaderRepository.SelectAll(), "Id", "ConcatReaderName");
            return model;
        }

        public static void Add(IssueAddModel model)
        {
            string query = String.Format("insert into Issues (book, reader, issue_date) values ({0}, {1}, '{2}')",
                model.Book.Id, model.SelectedReader, model.Issue.OccupiedDate.ToString("yyyy-MM-dd"));
            DataSet data = DbContext.DbConnection(query);
        }

        public static void Delete(int id)
        {
            string query = String.Format("delete from Issues where issue_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);
        }

        public static IssueAddModel Edit (int id)
        {
            string query = String.Format(issueViewQuery + "where issue_id = {0}", id);
            DataSet data = DbContext.DbConnection(query);
            IssueAddModel model = new IssueAddModel
            {
                Issue = DataToModel(data.Tables[0].Rows[0]),
                Author = AuthorRepository.DataToModel(data.Tables[0].Rows[0]),
                Book = BookRepository.DataToModel(data.Tables[0].Rows[0])
            };
            model.Readers = new SelectList(ReaderRepository.SelectAll(), "Id", "ConcatReaderName", model.Issue.ReaderId);

            return model;
        }

        public static void Edit (IssueAddModel model)
        {
            string query;
            if (model.Issue.ReturnedDate.HasValue)
            query = String.Format("update Issues set reader = {2}, issue_date = '{3}',  return_date = '{0}' where issue_id = {1}", 
                model.Issue.ReturnedDate.Value.ToString("yyyy-MM-dd"), model.Issue.Id, 
                model.SelectedReader, model.Issue.OccupiedDate.ToString("yyyy-MM-dd"));
            else query = String.Format("update Issues set reader = {2}, issue_date = '{3}', return_date = {0} where issue_id = {1}",
                null, model.Issue.Id,
                model.SelectedReader, model.Issue.OccupiedDate.ToString("yyyy-MM-dd"));
            DataSet data = DbContext.DbConnection(query);
        }

    }
}
