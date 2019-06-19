using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
                Adress = row.Field<string>("reader_adress")
            };
            return reader;
        }

        public static ReaderModel SelectReader (int id)
        {
            ReaderModel reader = DataToModel(DbContext.DbConnection(
                String.Format("select * from Readers", id)).Tables[0].Rows[0]);

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
                ("select * from Readers  (reader_surname like '%{0}%') or (reader_name like '%{0}%') or (reader_patronymic like '%{0}%')", symbols);
            List<ReaderModel> readers = ReaderList(query);
            return readers;
        }
    }
}
