using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories.CompositeModels;

namespace WebLib.Models.Repositories
{
    public class UserRepository
    {
        public static UserModel DataToUser (DataRow row)
        {
            return new UserModel
            {
                Id = row.Field<int>("user_id"),
                Login = row.Field<string>("user_name"),
                Password = row.Field<string>("user_password"),
                Post = row.Field<int>("user_role")
            };
        }

        public static List<UserModel> UserList (DataSet data)
        {
            List<UserModel> users = new List<UserModel>();
            foreach (DataRow row in data.Tables[0].Rows)
                users.Add(DataToUser(row));
            return users;
        }

        public static RoleModel DataToRole (DataRow row)
        {
            return new RoleModel
            {
                RoleId = row.Field<int>("role_id"),
                RoleName = row.Field<int>("role_name")
            };
        }

        public static List<RoleModel> RoleList()
        {
            List<RoleModel> roles = new List<RoleModel>();
            DataSet data = DbContext.DbConnection("select * from Roles");
            foreach (DataRow row in data.Tables[0].Rows)
                roles.Add(DataToRole(row));
            return roles;
        }

        public static UserRoleModel DataToUserRole (DataRow row)
        {
            return new UserRoleModel
            {
                User = DataToUser(row),
                Role = DataToRole(row)
            };
        }

        public static bool IsRegistered(string login)
        {
            string query = String.Format("select * from Users where user_name = {0}", login);
            DataSet data = DbContext.DbConnection(query);

            if (data.Tables[0].Rows.Count != 0) return true;
            else return false;
        }

        public static void RegistryEmployee(RegistryEmployeeModel model)
        {
            //TODO: добавить таблицу Employee и процедуру регистрации
        }

        public static void RegistryReader(RegistryReaderModel model)
        {
            string query = String.Format("exec RegistryReader {0}, {1}, {2}, {3}"); //TODO: доделать
        }
    }
}
