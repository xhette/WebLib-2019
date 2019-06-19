using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class LibraryRepository
    {
        public static LibraryModel DataToModel (DataRow row)
        {
            LibraryModel library = new LibraryModel
            {
                Id = row.Field<int>("lib_id"),
                Name = row.Field<string>("library_name"),
                Adress = row.Field<string>("library_adress")
            };

            return library;
        }

        public static List<LibraryModel> SelectAll()
        {
            string sqlQuery = String.Format("select * from Libraries");
            List<LibraryModel> libraries = LibraryList(sqlQuery);
            return libraries;
        }

        public static List<LibraryModel> SelectBySearch(string symbols)
        {
            string sqlQuery = String.Format("select * from Libraries where library_name like '%{0}%'", symbols);
            List<LibraryModel> libraries = LibraryList(sqlQuery);
            return libraries;
        }

        private static List<LibraryModel> LibraryList(string sqlQuery)
        {
            List<LibraryModel> libraries = new List<LibraryModel>();
            DataSet data = DbContext.DbConnection(sqlQuery);
            foreach (DataRow row in data.Tables[0].Rows)
            {
                libraries.Add(DataToModel(row));
            }

            return libraries;
        }

        public static void Edit(LibraryModel model)
        {
            string sqlQuery = String.Format("update Libraries set library_name = '{0}', library_adress = '{1}' where lib_id = {2}",
                model.Name, model.Adress, model.Id);

           DataSet data = DbContext.DbConnection(sqlQuery);
        }

        public static LibraryModel Edit(int id)
        {
            string sqlQuery = String.Format("select * from Libraries where lib_id = {0}", id);
            DataSet data = DbContext.DbConnection(sqlQuery);
            LibraryModel library = DataToModel(data.Tables[0].Rows[0]);

            return library;
        }

        public static void Delete (int id)
        {
            string sqlQuery = String.Format("delete from Libraries where lib_id = {0}", id);
            DataSet data = DbContext.DbConnection(sqlQuery);
        }

        public static void Add (LibraryModel model)
        {
            string sqlQuery = String.Format("insert into Libraries (library_name, library_adress) values ('{0}', '{1}')",
                model.Name, model.Adress);
            DataSet data = DbContext.DbConnection(sqlQuery);
        }
    }
}
