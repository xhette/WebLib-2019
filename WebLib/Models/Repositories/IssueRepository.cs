using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories.CompositeModels.Issues;

namespace WebLib.Models.Repositories
{
    public class IssueRepository
    {
        private string issueViewQuery = String.Format
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
    }
}
