using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories.CompositeModels;

namespace WebLib.Models.Repositories
{
    public class ReaderRepository
    {

        public static ReaderModel DataToModel (DataRow row)
        {
            ReaderModel reader = new ReaderModel
            {
                Id = row.Field<int>("reader_card"),
                Surname = row.Field<string>("reader_surname"),
                FirstName = row.Field<string>("reader_name"),
                Patronymic = row.Field<string>("reader_patronymic"),
                PhoneNumber = row.Field<string>("reader_phone"),
                Adress = row.Field<string>("reader_adress"),
                UserId = row.Field<int>("reader_account")
            };
            return reader;
        }

        public static ReaderModel SelectReader (int id)
        {
            ReaderModel reader = DataToModel(DbContext.DbConnection(
                String.Format("select * from Readers where reader_card = {0}", id)).Tables[0].Rows[0]);

            return reader;
        }

        public static List<ReaderModel> ReaderList(string query)
        {
            List<ReaderModel> readers = new List<ReaderModel>();
            DataSet data = DbContext.DbConnection(query);
            foreach (DataRow row in data.Tables[0].Rows)
                readers.Add(DataToModel(row));
            return readers;
        }

        public static List<ReaderModel> SelectAll()
        {
            string query = String.Format("select * from Readers");
            List<ReaderModel> readers = ReaderList(query);
            return readers;
        }

        public static List<ReaderModel> SelectBySearch(string symbols)
        {
            string query = String.Format
                ("select * from Readers where (reader_surname like '%{0}%') or (reader_name like '%{0}%') or (reader_patronymic like '%{0}%')", symbols);
            List<ReaderModel> readers = ReaderList(query);
            return readers;
        }

        public static List<ReaderModel> SelectByDeptorsSearch(string symbols)
        {
            string query = String.Format
                ("select reader_card, reader_surname, reader_name, reader_patronymic, reader_adress, reader_phone from Readers join Issues on reader = reader_card where ((reader_surname like '%{0}%') or (reader_name like '%{0}%') or (reader_patronymic like '%{0}%')) and (issue_date <= DATEADD(DAY, -14, SYSDATETIME())) and(return_date IS NULL)", 
                symbols);
            List<ReaderModel> readers = ReaderList(query);
            return readers;
        }


        public static List<ReaderModel> SelectDeptors()
        {
            string query = String.Format
                ("select reader_card, reader_surname, reader_name, reader_patronymic, reader_adress, reader_phone from Readers join Issues on reader = reader_card where (issue_date <= DATEADD(DAY, -14, SYSDATETIME())) and(return_date IS NULL)");
            return ReaderList(query);
        }

        #region Librarian

        public static ReaderModel Add()
        {
            ReaderModel model = new ReaderModel();
            return model;
        }

        public static void Add(ReaderModel model)
        {
            if (model.Patronymic == null) model.Patronymic = "";
            string query = String.Format("insert into Readers (reader_surname, reader_name, reader_patronymic, reader_adress, reader_phone) values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                model.Surname, model.FirstName, model.Patronymic, model.Adress, model.PhoneNumber);
            DataSet data = DbContext.DbConnection(query);
        }

        public static ReaderModel Edit(int id)
        {
            ReaderModel model = DataToModel(DbContext
                .DbConnection(String.Format("select * from Readers where reader_card = {0}", id))
                .Tables[0].Rows[0]);
            return model;
        }

        public static void Edit (ReaderModel model)
        {
            if (model.Patronymic == null) model.Patronymic = "";
            string query = String.Format
                ("update Readers set reader_surname = '{0}', reader_name = '{1}', reader_patronymic = '{2}', reader_adress = '{3}', reader_phone = '{4}', reader_account = {6} where reader_card = {5}",
                model.Surname, model.FirstName, model.Patronymic, model.Adress, model.PhoneNumber, model.Id, model.UserId);
            DataSet data = DbContext.DbConnection(query);
        }

        public static void Delete (int id)
        {
            string query = String.Format("delete from Readers where reader_card = {0}", id);
            DataSet data = DbContext.DbConnection(query);
        }

        #endregion
    }
}
