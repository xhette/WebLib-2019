using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class DbContext
    {
        private static string connectionString = String.Format("Data Source = localhost; Initial Catalog = Library; Integrated Security = True;");

        public static DataSet DbConnection (string query)
        {
            DataSet data = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }
    }
}
