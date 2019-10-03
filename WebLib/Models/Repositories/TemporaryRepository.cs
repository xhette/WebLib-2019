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
            //this.undo = 0;
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


            this.undo = TempJournal.Count - 1;
        }

        public void TemporaryOperation()
        {
            switch (TempJournal[undo].TableName)
            {
                case "Authors":
                    Authors(undo);
                    break;
                case "Books":
                    Books(undo);
                    break;
                case "Deliveries":
                    Deliveries(undo);
                    break;
                case "Departments":
                    Departments(undo);
                    break;
                case "Issues":
                    Issues(undo);
                    break;
                case "Libraries":
                    Libraries(undo);
                    break;
                case "Readers":
                    Readers(undo);
                    break;
                case "Roles":
                    Roles(undo);
                    break;
                case "Shops":
                    Shops(undo);
                    break;
                case "Users":
                    Users(undo);
                    break;

                default: break;
            }

            TempJournal.Clear();
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
        }

        public void Undone()
        {

            undo--; 

            if (undo >= 0)
            {
                TemporaryOperation();
            }
        }

        public void Redone()
        {
            undo++;
            if (undo < TempJournal.Count-1)
            {
                TemporaryOperation();
            }
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
            if (!TempJournal[index].OperationName.Equals("delete")) AuthorRepository.Edit(author);
            else AuthorRepository.Add(author);
        }

        private void Books (int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Books", TempJournal[index].OperationDate.ToString(),
                "book_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Books", TempJournal[index].OperationDate.ToString(),
                "book_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            BookModel book = BookRepository.DataToModel(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                query = String.Format("update Books set author = {0}, title = '{1}', department = {2} where book_id = {3}",
                book.AuthorId, book.Title, book.DepartmentId, book.Id);
            }
            else
            {
                query = String.Format("insert into Books vakues ({0}, '{1}', {2})",
               book.AuthorId, book.Title, book.DepartmentId);
            }
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
            if (!TempJournal[index].OperationName.Equals("delete")) LibraryRepository.Edit(library);
            else LibraryRepository.Add(library);
        }

        private void Deliveries(int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Deliveries", TempJournal[index].OperationDate.ToString(),
                "delivery_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Deliveries", TempJournal[index].OperationDate.ToString(),
                "delivery_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            DeliveryModel delivery = DeliveryRepository.DataToModel(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                query = String.Format("update Deliveries set book = {0}, amount = {1}, cost = {2}, summ = {3}, shop = {4} where delivery_id = {5}",
                delivery.BookId, delivery.Amount, delivery.Cost, delivery.Summ, delivery.Shop, delivery.Id);
            }
            else
            {
                query = String.Format("insert into Deliveries values ({0}, {1}, {2}, {3}, {4})",
                delivery.BookId, delivery.Amount, delivery.Cost, delivery.Summ, delivery.Shop);
            }
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
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                if (issue.ReturnedDate.HasValue)
                    query = String.Format("update Issues set reader = {2}, issue_date = '{3}',  return_date = '{0}' where issue_id = {1}",
                        issue.ReturnedDate.Value.ToString("yyyy-MM-dd"), issue.Id,
                        issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
                else query = String.Format("update Issues set reader = {2}, issue_date = '{3}',  return_date = '{0}' where issue_id = {1}",
                        null, issue.Id,
                        issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                if (issue.ReturnedDate.HasValue)
                    query = String.Format("insert into Issues values({1}, '{2}',  '{0}')",
                      issue.ReturnedDate.Value.ToString("yyyy-MM-dd"), issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
                else query = String.Format("insert into Issues values({1}, '{2}',  '{0}')",
                       null, issue.ReaderId, issue.OccupiedDate.ToString("yyyy-MM-dd"));
            }
            DataSet data = DbContext.DbConnection(query);
        }

        private void Departments(int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Departments", TempJournal[index].OperationDate.ToString(),
                "department_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Departments", TempJournal[index].OperationDate.ToString(),
                "department_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            DepartmentModel department = DepartmentRepository.DataToModel(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                query = String.Format("update Departments set department_name = {0}, in_library = {1} where department_id = {2}",
                department.Name, department.LibraryId, department.Id);
            }
            else
            {
                query = String.Format("insert into Departments values ('{0}', {1})", department.Name, department.LibraryId);
            }
            DataSet data = DbContext.DbConnection(query);
        }

        private void Shops(int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Shops", TempJournal[index].OperationDate.ToString(),
                "shop_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Shops", TempJournal[index].OperationDate.ToString(),
                "shop_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            ShopModel shop = ShopRepository.DataToModel(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete")) ShopRepository.Edit(shop);
            else ShopRepository.Add(shop);
        }

        private void Readers(int index)
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
            if (!TempJournal[index].OperationName.Equals("delete")) ReaderRepository.Edit(reader);
            else
            {
                string query = String.Format("insert into Readers values ('{0}', '{1}', '{2}', '{3}','{4}', {5})",
                    reader.Surname, reader.FirstName, reader.Patronymic, reader.Adress, reader.PhoneNumber, reader.UserId);
            }
        }

        private void Users(int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Users", TempJournal[index].OperationDate.ToString(),
                "user_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Users", TempJournal[index].OperationDate.ToString(),
                "user_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            UserModel user = UserRepository.DataToUser(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                query = String.Format("update Users set user_name = '{0}', user_password = '{1}', user_role = {2} where user_id = {3}",
                user.Login, user.Password, user.Post, user.Id);
            } else
            {
                query = String.Format("insert into Users values ('{0}', '{1}', {2})", user.Login, user.Password, user.Post);
            }
            DataSet data = DbContext.DbConnection(query);
        }

        private void Roles(int index)
        {
            string tempQuery;
            string query = "";
            if (TempJournal[index].OperationName.Equals("insert")) tempQuery = String.Format("select * from {0} for system_time as of '{1}' where {2} = {3}",
                "Roles", TempJournal[index].OperationDate.ToString(),
                "role_id", TempJournal[index].ColumnId);
            else tempQuery = String.Format("select * from {0} for system_time contained in ('2001-01-01 00:00:00.00', '{1}') where {2} = {3}",
                "Roles", TempJournal[index].OperationDate.ToString(),
                "role_id", TempJournal[index].ColumnId);
            DataSet tempData = DbContext.DbConnection(tempQuery);
            RoleModel role = UserRepository.DataToRole(tempData.Tables[0].Rows[0]);
            if (!TempJournal[index].OperationName.Equals("delete"))
            {
                query = String.Format("update Roles set role_name = '{0}' where role_id = {1}",
                role.RoleName, role.RoleId);
            }
            else
            {
                query = String.Format("insert into Roles values ('{0}')", role.RoleName);
            }
            DataSet data = DbContext.DbConnection(query);
        }
    }
}
