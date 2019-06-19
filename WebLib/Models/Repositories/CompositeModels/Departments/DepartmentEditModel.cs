using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Departments
{
    public class DepartmentEditModel
    {
        public DepartmentModel Department { get; set; }

        public SelectList Libraries { get; set; }

        public int SelectedLibrary { get; set; }
    }
}
