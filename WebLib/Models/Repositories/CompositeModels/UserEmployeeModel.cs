using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels
{
    public class UserEmployeeModel
    {
        public EmployeeModel EmployeeData { get; set; }

        public UserModel AccountData { get; set; }

    }
}
