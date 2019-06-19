using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebLib.Models.Repositories.CompositeModels.Departments;

namespace WebLib.Models.Repositories
{
    public class DepartmentRepository
    {
        public static DepartmentModel DataToModel(DataRow row)
        {
            DepartmentModel department = new DepartmentModel
            {
                Id = row.Field<int>("department_id"),
                Name = row.Field<string>("department_name"),
                LibraryId = row.Field<int>("in_library")
            };

            return department;
        }
        
        public static List<DepartmentModel> DepartmentList (string sqlQuery)
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            DataSet data = DbContext.DbConnection(sqlQuery);

            foreach (DataRow row in data.Tables[0].Rows)
                departments.Add(DataToModel(row));
            return departments;

        }
        
        public static List<DepartmentModel> SelectAll()
        {
            string sqlQuery = String.Format("select * from Departments");
            List<DepartmentModel> departments = DepartmentList(sqlQuery);
            return departments;
        }

        public static List<DepartmentModel> SelectBySearch(string symbols)
        {
            string sqlQuery = String.Format("select * from Departments where department_name like '%{0}%'", symbols);
            List<DepartmentModel> departments = DepartmentList(sqlQuery);
            return departments;
        }

        public static List<DepartmentModel> SelectByLibrary(int id)
        {
            string sqlQuery = String.Format("select * from Departments where in_library = {0}", id);
            List<DepartmentModel> departments = DepartmentList(sqlQuery);
            return departments;
        }

        public static List<DepartmentViewModel> DepartmentsWithLibrary(List<DepartmentModel> departments)
        {
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>();
            List<LibraryModel> libraries = LibraryRepository.SelectAll();

            foreach (LibraryModel library in libraries)
            {
                departmentList.Add(
                    new DepartmentViewModel
                    {
                        Library = library,
                        DepartmentsInLibrary = departments.Where(d => d.LibraryId == library.Id).ToList()
                    });
            }

            return departmentList;
        }

        public static List<DepartmentViewModel> SelectViewAll()
        {
            List<DepartmentViewModel> departments = DepartmentsWithLibrary(SelectAll());
            return departments;
        }

        public static List<DepartmentViewModel> SelectViewBySearch(string symbols)
        {
            List<DepartmentViewModel> departments = DepartmentsWithLibrary(SelectBySearch(symbols));
            return departments;
        }

        public static DepartmentViewModel SelectViewByLibrary(int id)
        {
            string departmentQuery = String.Format("select * from Departments where in_library = {0}", id);
            List<DepartmentModel> departments = DepartmentList(departmentQuery);
            DataSet libraryset = DbContext.DbConnection(String.Format("select * from Libraries where lib_id = {0}", id));
            LibraryModel library = LibraryRepository.DataToModel(libraryset.Tables[0].Rows[0]);

            DepartmentViewModel department = new DepartmentViewModel
            {
                Library = library,
                DepartmentsInLibrary = departments
            };

            return department;
        }
        
        public static DepartmentEditModel Edit (int id)
        {
            DepartmentModel department = DataToModel(DbContext.DbConnection(String.Format
                ("select * from Departments where department_id = {0}", id)).Tables[0].Rows[0]);

            DepartmentEditModel model = new DepartmentEditModel
            {
                Department = department,
                Libraries = new SelectList(LibraryRepository.SelectAll(), "Id", "Name", department.LibraryId),
                SelectedLibrary = department.LibraryId
            };

            return model;
        }

        public static void Edit (DepartmentEditModel model)
        {
            string sqlQuery = String.Format("update Departments set department_name = '{0}', in_library = {1} where department_id = {2}",
                model.Department.Name, model.SelectedLibrary, model.Department.Id);

            DataSet data = DbContext.DbConnection(sqlQuery);
        }

        public static void Add(DepartmentEditModel model)
        {
            string sqlQuery = String.Format("insert into Departments (department_name, in_library) values ('{0}', {1})",
                model.Department.Name, model.SelectedLibrary);

            DataSet data = DbContext.DbConnection(sqlQuery);
        }
    }
}
