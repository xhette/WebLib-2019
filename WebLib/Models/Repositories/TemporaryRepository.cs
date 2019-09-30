using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories;

namespace WebLib.Models
{
    public class TemporaryRepository
    {
        private int undo;
        private int redo;
        private List<TemporaryModel> TempJournal;

        public TemporaryRepository()
        {
            this.undo = 0;
            this.TempJournal = new List<TemporaryModel>();

            string query = String.Format("select * from _TempJournal order by operation_time desc");
            DataSet journalData = DbContext.DbConnection(query);

            foreach (DataRow row in journalData.Tables[0].Rows)
            {
                TempJournal.Add(new TemporaryModel
                {
                    Id = row.Field<int>("id"),
                    TableName = row.Field<string>("table_name"),
                    OperationName = row.Field<string>("operation_name"),
                    OperationDate = row.Field<DateTime>("operation_time"),
                    ColumnId = row.Field<int>("column_id")
                });
            }


            this.redo = TempJournal.Count - 1;
        }

        public void Undone()
        {
            redo = 0;
            string valid = "";
            string tableName = "";
            string tempTableName = "";
            string idName = "";

            switch (TempJournal[undo].TableName)
            {
                case "Authors": 
                    tableName = "Authors";
                    tempTableName = "Authors_History";
                    idName = "author_id";
                    break;
                case "Books":
                    tableName = "Books";
                    tempTableName = "Books_History";
                    idName = "book_id";
                    break;
                case "Deliveries":
                    tableName = "Deliveries";
                    tempTableName = "Deliveries_History";
                    idName = "delivery_id";
                    break;
                case "Departments":
                    tableName = "Departments";
                    tempTableName = "Departments_History";
                    idName = "department_id";
                    break;
                case "Issues":
                    tableName = "Issues";
                    tempTableName = "Issues_History";
                    idName = "issue_id";
                    break;
                case "Libraries":
                    tableName = "Libraries";
                    tempTableName = "Libraries_History";
                    idName = "lib_id";
                    break;
                case "Readers": 
                    tableName = "Readers";
                    tempTableName = "Readers_History";
                    idName = "reader_card";
                    break;
                case "Roles":
                    tableName = "Roles";
                    tempTableName = "Roles_History";
                    idName = "role_id";
                    break;
                case "Shops":
                    tableName = "Shops";
                    tempTableName = "Shops_History";
                    idName = "shop_id";
                    break;
                case "Users":
                    tableName = "Users";
                    tempTableName = "Users_History";
                    idName = "user_id";
                    break;
                default: break;
            }

            if (TempJournal[undo].OperationName.Equals("insert"))
                valid = String.Format("ValidFrom");
            else valid = String.Format("ValidTo");

            string tempQuery = String.Format("select * from {0} where ({1} = {2}) and ({3} = {4})",
                tempTableName, idName, TempJournal[undo].ColumnId, valid, TempJournal[undo].OperationDate);

            DataSet data = DbContext.DbConnection(tempQuery);

            switch (TempJournal[undo].TableName)
            {
                case "Authors":
                    break;
                case "Books":
                    break;
                case "Deliveries":
                    break;
                case "Departments":
                    break;
                case "Issues":
                    break;
                case "Libraries":
                    break;
                case "Readers":
                    break;
                case "Roles":
                    break;
                case "Shops":
                    break;
                case "Users":
                    break;
                default: break;
            }
        }

        public void Redone()
        {

        }

        private void Authors(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Authors", TempJournal[index].OperationDate.ToString(),
                "author_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Authors", TempJournal[index].OperationDate.ToString(),
                "author_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            AuthorModel author = AuthorRepository.DataToModel(tempData.Tables[0].Rows[0]);
            AuthorRepository.Edit(author);
        }

        private void Books (int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Books", TempJournal[index].OperationDate.ToString(),
                "book_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Books", TempJournal[index].OperationDate.ToString(),
                "book_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            BookModel book = BookRepository.DataToModel(tempData.Tables[0].Rows[0]);
            string query = String.Format("update Books set author = {0}, title = '{1}', department = {2} where book_id = {3}",
                book.AuthorId, book.Title, book.DepartmentId, book.Id);
            DataSet data = DbContext.DbConnection(query);
        }

        private void Libraries(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Libraries", TempJournal[index].OperationDate.ToString(),
                "lib_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Libraries", TempJournal[index].OperationDate.ToString(),
                "lib_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            LibraryModel library = LibraryRepository.DataToModel(tempData.Tables[0].Rows[0]);
            LibraryRepository.Edit(library);
        }

        private void Deliveries(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Deliveries", TempJournal[index].OperationDate.ToString(),
                "delivery_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Deliveries", TempJournal[index].OperationDate.ToString(),
                "delivery_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            DeliveryModel delivery = DeliveryRepository.DataToModel(tempData.Tables[0].Rows[0]);
            string query = String.Format("update Deliveries set book = {0}, amount = {1}, cost = {2}, summ = {3}, shop = {4} where delivery_id = {5}",
                delivery.BookId, delivery.Amount, delivery.Cost, delivery.Summ, delivery.Shop, delivery.Id);
            DataSet data = DbContext.DbConnection(query);
        }

        private void Issues(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Issues", TempJournal[index].OperationDate.ToString(),
                "issue_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Issues", TempJournal[index].OperationDate.ToString(),
                "issue_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            IssueModel issue = IssueRepository.DataToModel(tempData.Tables[0].Rows[0]);
            string query = "";
            if (issue.ReturnedDate.HasValue)
                query = String.Format("update Issues set reader = {2}, issue_date = '{3}',  return_date = '{0}' where issue_id = {1}",
                    issue.ReturnedDate.Value.ToString("yyyy-MM-dd"), issue.Id,
                    issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
            else query = String.Format("update Issues set reader = {2}, issue_date = '{3}',  return_date = '{0}' where issue_id = {1}",
                    null, issue.Id,
                    issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
            DataSet data = DbContext.DbConnection(query);
        }

        private void Departments(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Departments", TempJournal[index].OperationDate.ToString(),
                "department_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Departments", TempJournal[index].OperationDate.ToString(),
                "department_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            DepartmentModel department = DepartmentRepository.DataToModel(tempData.Tables[0].Rows[0]);
            string query = String.Format("update Departments set department_name = {0}, in_library = {1} where department_id = {2}",
                department.Name, department.LibraryId, department.Id);
            DataSet data = DbContext.DbConnection(query);
        }

        private void Shops(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Shops", TempJournal[index].OperationDate.ToString(),
                "shop_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Shops", TempJournal[index].OperationDate.ToString(),
                "shop_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            ShopModel shop = ShopRepository.DataToModel(tempData.Tables[0].Rows[0]);
            ShopRepository.Edit(shop);
        }

        private void Libraries(int index)
        {
            string tempQuery;
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Readers", TempJournal[index].OperationDate.ToString(),
                "reader_card", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Readers", TempJournal[index].OperationDate.ToString(),
                "reader_card", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            ReaderModel reader = ReaderRepository.DataToModel(tempData.Tables[0].Rows[0]);
            LibraryRepository.Edit(reader);
        }
    }
}
