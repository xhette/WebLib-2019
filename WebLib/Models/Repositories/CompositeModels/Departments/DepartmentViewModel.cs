using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Departments
{
    public class DepartmentViewModel
    {
        public LibraryModel Library { get; set; }
        public List<DepartmentModel> DepartmentsInLibrary { get; set; }
    }
}
