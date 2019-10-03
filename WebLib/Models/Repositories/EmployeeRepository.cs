using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories
{
    public class EmployeeRepository
    {
        public static EmployeeModel DataToModel (DataRow row)
        {
            return new EmployeeModel
            {
                Id = row.Field<int>("employee_id"),
                Surname = row.Field<string>("employee_surname"),
                FirstName = row.Field<string>("employee_name"),
                Patronymic = row.Field<string>("employee_patronymic"),
                PhoneNumber = row.Field<string>("employee_phone"),
                UserId = row.Field<int>("employee_account")
            };
        }

        public static List<EmployeeModel> EmployeeList (DataSet data)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach (DataRow row in data.Tables[0].Rows)
                employees.Add(DataToModel(row));
            return employees;

        }
    }
}
