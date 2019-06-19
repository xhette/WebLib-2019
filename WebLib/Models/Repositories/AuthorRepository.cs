using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class AuthorRepository
    {
        public static AuthorModel DataToModel (DataRow row)
        {
            AuthorModel author = new AuthorModel
            {
                Id = row.Field<int>("author_id"),
                Surname = row.Field<string>("author_surname"),
                FirstName = row.Field<string>("author_name"),
                Patronymic = row.Field<string>("author_patronymic")
            };

            return author;
        }

        public static List<AuthorModel> AuthorList (string sqlQuery)
        {
            List<AuthorModel> authors = new List<AuthorModel>();
            DataSet data = DbContext.DbConnection(sqlQuery);

            foreach (DataRow row in data.Tables[0].Rows)
                authors.Add(DataToModel(row));

            return authors;
        }

        public static List<AuthorModel> SelectAll()
        {
            string sqlQuery = String.Format("select * from Authors");
            List<AuthorModel> authors = AuthorList(sqlQuery);
            return authors;
        }

        public static List<AuthorModel> SelectBySearch(string symbols)
        {
            string sqlQuery = String.Format
                ("select * from authors where (author_surname like '%{0}%') or (author_name like '%{0}%') or (author_patronymic like '%{0}%')", symbols);
            List<AuthorModel> authors = AuthorList(sqlQuery);
            return authors;
        }

        public static AuthorModel Edit(int id)
        {
            string commandString = String.Format("select * from Authors where author_id = {0}", id);
            DataSet data = DbContext.DbConnection(commandString);
            AuthorModel model = DataToModel(data.Tables[0].Rows[0]);
            return model;
        }

        public static void Edit(AuthorModel model)
        {
            if (model.Patronymic == null) model.Patronymic = "";
            string commandString = String.Format("update Authors set author_surname = '{0}', author_name = '{1}', author_patronymic = '{2}' where author_id = {3}",
                model.Surname, model.FirstName, model.Patronymic, model.Id);

            DataSet data = DbContext.DbConnection(commandString);
        }

        public static void Delete(int id)
        {
            string commandString = String.Format("delete from Authors where author_id = {0}", id);
            DataSet data = DbContext.DbConnection(commandString);
        }

        public static void Add(AuthorModel model)
        {
            string commandString;
            if (model.Patronymic != null)
                commandString = String.Format
                    ("insert into Authors (author_surname, author_name, author_patronymic) values ('{0}', '{1}', '{2}')", model.Surname, model.FirstName, model.Patronymic);
            else
                commandString = String.Format
                    ("insert into Authors (author_surname, author_name) values ('{0}', '{1}')", model.Surname, model.FirstName);

            DataSet data = DbContext.DbConnection(commandString);
        }
    }
}
