using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels
{
    public class UserRoleModel
    {
        public UserModel User { get; set; }

        public RoleModel Role { get; set; }
    }
}
