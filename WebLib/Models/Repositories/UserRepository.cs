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

        public static RoleModel DataToRole (DataRow row)
        {
            return new RoleModel
            {
                RoleId = row.Field<int>("role_id"),
                RoleName = row.Field<int>("role_name")
            };
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
    }
}
