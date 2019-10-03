using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels
{
    public class RegistryEmployeeModel
    {
        public int Post { get; set; }

        public UserModel UserData { get; set; }

        public EmployeeModel EmployeeData { get; set; }
    }
}
