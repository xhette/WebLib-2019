using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLib.Models;

namespace WebLib.Controllers
{
    public class LibrarianController : Controller
    {
        static string sqlConnectionString = String.Format("Data Source=localhost;Initial Catalog=Library;Integrated Security=True;");

        public IActionResult Index()
        {
            return View();
        }

        #region BooksControllers

        public ViewResult Books()
        {
            List<BookViewModel> listBooks = ShowBooks();
            ViewBag.listBooks = listBooks;
            return View(listBooks);
        }
        
        public ViewResult SearchBooks(string symbols)
        {
            string sqlQuery = String.Format("select * from (Authors join (Books join (Departments join Libraries on in_library = lib_id) on department = department_id) on author = author_id) where title like '%{0}%'", symbols);
            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                adapter.Fill(data);
                connection.Close();
            }

            List<BookViewModel> listBooks = BookList(data);
            ViewBag.listBooks = listBooks;
            return View("SearchBooks", listBooks);
        }

        [HttpGet]
        public ViewResult EditBook(int Id)
        {
            BooModel editmodel = EditModel(Id);
            return View(editmodel);
        }

        [HttpPost]
        public ViewResult EditBook (BooModel model)
        {
            if (ModelState.IsValid)
            {
                string cmdString = String.Format("exec EditBook {0}, '{1}', '{2}', '{3}', '{4}', {5}",
                    model.Book.Id, model.Author.Surname, model.Author.FirstName, model.Author.Patronymic, model.Book.Title, model.SelectedDepartmentId);
                DataSet data = new DataSet();
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(cmdString, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);
                    connection.Close();
                }
                List<BookViewModel> listBooks = ShowBooks();
                ViewBag.listBooks = listBooks;
                return View("Books", listBooks);
            } else
            {
                BooModel editmodel = EditModel(model.Book.Id);
                return View(editmodel);
            }
        }


        [HttpGet]
        public ViewResult AddBook()
        {
            BooModel model = new BooModel
            {
                Author = new AuthorModel(),
                Book = new BookModel(),
            };


            DataSet dataBookSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {

                model.Departments = new SelectList(GetDepartmentList(1), "Id", "Name", 1);

                DataSet librarySet = new DataSet();
                string commandLibraryString = String.Format("select * from Libraries where lib_id = {0}", 1);
                SqlCommand commandLibrary = new SqlCommand(commandLibraryString, connection);
                SqlDataAdapter adapterLibrary = new SqlDataAdapter(commandLibrary);
                adapterLibrary.Fill(librarySet);
                LibraryModel lib = new LibraryModel();
                lib.Id = librarySet.Tables[0].Rows[0].Field<int>("lib_id");
                lib.Name = librarySet.Tables[0].Rows[0].Field<string>("library_name");
                lib.Adress = librarySet.Tables[0].Rows[0].Field<string>("library_adress");

                model.Libraries = new SelectList(GetLibraryList(), "Id", "Name", lib.Id);
                connection.Close();

                return View(model);
            }
        }

        [HttpPost]
        public ViewResult AddBook(BooModel model)
        {
            if (ModelState.IsValid)
            {
                DataSet dataBookSet = new DataSet();
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string commandString = String.Format("exec AddBook '{0}', '{1}', '{2}', '{3}', {4}",
                        model.Author.Surname, model.Author.FirstName, model.Author.Patronymic, model.Book.Title, model.SelectedDepartmentId);
                    SqlCommand comd = new SqlCommand(commandString, connection);
                    SqlDataAdapter adapterLibrary = new SqlDataAdapter(comd);
                    try
                    {
                        adapterLibrary.Fill(dataBookSet);
                    }
                    catch (SqlException exc)
                    {

                    }
                }

                List<BookViewModel> listBooks = ShowBooks();
                ViewBag.listBooks = listBooks;
                return View("Books", listBooks);
            }
            else
            {
                DataSet dataBookSet = new DataSet();
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Library;Integrated Security=True;"))
                {

                    model.Departments = new SelectList(GetDepartmentList(1), "Id", "Name", 1);

                    DataSet librarySet = new DataSet();
                    string commandLibraryString = String.Format("select * from Libraries where lib_id = {0}", 1);
                    SqlCommand commandLibrary = new SqlCommand(commandLibraryString, connection);
                    SqlDataAdapter adapterLibrary = new SqlDataAdapter(commandLibrary);
                    adapterLibrary.Fill(librarySet);
                    LibraryModel lib = new LibraryModel();
                    lib.Id = librarySet.Tables[0].Rows[0].Field<int>("lib_id");
                    lib.Name = librarySet.Tables[0].Rows[0].Field<string>("library_name");
                    lib.Adress = librarySet.Tables[0].Rows[0].Field<string>("library_adress");

                    model.Libraries = new SelectList(GetLibraryList(), "Id", "Name", lib.Id);
                    connection.Close();

                    return View(model);
                }
            }
        }

        [HttpGet]
        public ViewResult DeleteBook(int id)
        {
            DataSet dsDelete = new DataSet();
            string cmdString = String.Format("delete from Books where book_id = {0}", id);
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand(cmdString, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsDelete);
                connection.Close();
            }

            List<BookViewModel> listBooks = ShowBooks();
            ViewBag.listBooks = listBooks;
            return View("Books", listBooks);
        }
        #endregion

        #region Books SQL
        public static List<BookViewModel> ShowBooks()
        {
            DataSet dsBooks = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("EXEC GetBooks", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsBooks);
                connection.Close();
            }

            List<BookViewModel> lstBooks = BookList(dsBooks);
            return lstBooks;
        }

        public static BooModel EditModel(int id)
        {
            BooModel model = new BooModel
            {
                Author = new AuthorModel(),
                Book = new BookModel()
            };
            DataSet dataBookSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                string commandBookString = String.Format("select * from (Authors join Books on author = author_id) where book_id = {0}", id);
                SqlCommand cmdBook = new SqlCommand(commandBookString, connection);
                SqlDataAdapter adapterBooks = new SqlDataAdapter(cmdBook);
                adapterBooks.Fill(dataBookSet);
                model.Author.Id = dataBookSet.Tables[0].Rows[0].Field<int>("author_id");
                model.Author.Surname = dataBookSet.Tables[0].Rows[0].Field<string>("author_surname");
                model.Author.FirstName = dataBookSet.Tables[0].Rows[0].Field<string>("author_name");
                model.Author.Patronymic = dataBookSet.Tables[0].Rows[0].Field<string>("author_patronymic");
                model.Book.Id = dataBookSet.Tables[0].Rows[0].Field<int>("book_id");
                model.Book.AuthorId = dataBookSet.Tables[0].Rows[0].Field<int>("author");
                model.Book.Title = dataBookSet.Tables[0].Rows[0].Field<string>("title");
                model.Book.DepartmentId = dataBookSet.Tables[0].Rows[0].Field<int> ("department");

                DataSet departmentSet = new DataSet();
                string commandDepartmentString = String.Format("select * from Departments where department_id = {0}", model.Book.DepartmentId);
                SqlCommand cmdDepartment = new SqlCommand(commandDepartmentString, connection);
                SqlDataAdapter departmentData = new SqlDataAdapter(cmdDepartment);
                departmentData.Fill(departmentSet);
                DepartmentModel department = new DepartmentModel();
                department.Id = departmentSet.Tables[0].Rows[0].Field<int>("department_id");
                department.Name = departmentSet.Tables[0].Rows[0].Field<string>("department_name");
                department.LibraryId = departmentSet.Tables[0].Rows[0].Field<int>("in_library");

                model.Departments = new SelectList(GetDepartmentList(department.LibraryId), "Id", "Name", department.Id);

               DataSet librarySet = new DataSet();
                string commandLibraryString = String.Format("select * from Libraries where lib_id = {0}", department.LibraryId);
                SqlCommand commandLibrary = new SqlCommand(commandLibraryString, connection);
                SqlDataAdapter adapterLibrary = new SqlDataAdapter(commandLibrary);
                adapterLibrary.Fill(librarySet);
                LibraryModel lib = new LibraryModel();
                lib.Id = librarySet.Tables[0].Rows[0].Field<int>("lib_id");
                lib.Name = librarySet.Tables[0].Rows[0].Field<string>("library_name");
                lib.Adress = librarySet.Tables[0].Rows[0].Field<string>("library_adress");

                model.Libraries = new SelectList(GetLibraryList(), "Id", "Name", lib.Id);

                model.SelectedDepartmentId = department.Id;
                model.SelectedLibraryId = lib.Id;
                connection.Close();
            }

            return model;
        }
        #endregion


        #region AuthorsControllers
        public ViewResult Authors()
        {
            DataSet dsAuthors = new DataSet();
            List<AuthorModel> authors = new List<AuthorModel>();
            string commandString = String.Format("select * from Authors");
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);
                adapter.Fill(dsAuthors);
                connection.Close();
            }

            foreach(DataRow data in dsAuthors.Tables[0].Rows)
            {
                authors.Add(
                    new AuthorModel
                    {
                        Id = data.Field<int>("author_id"),
                        Surname = data.Field<string>("author_surname"),
                        FirstName = data.Field<string>("author_name"),
                        Patronymic = data.Field<string>("author_patronymic")
                    }
                );
            }

            return View(authors);
        }

        public ActionResult DeleteAuthor (int Id)
        {
            string commandString = String.Format("delete from Authors where author_id = {0}", Id);
            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);
                adapter.Fill(data);

                connection.Close();
            }

            return RedirectToAction("Authors", "Librarian");
        }

        [HttpGet]
        public ActionResult EditAuthor(int Id)
        {
            AuthorModel model = new AuthorModel();
            string commandString = String.Format("select * from Authors where author_id = {0}", Id);
            DataSet data = new DataSet();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);
                adapter.Fill(data);
                connection.Close();
            }

            model.Id = data.Tables[0].Rows[0].Field<int>("author_id");
            model.Surname = data.Tables[0].Rows[0].Field<string>("author_surname");
            model.FirstName = data.Tables[0].Rows[0].Field<string>("author_name");
            model.Patronymic = data.Tables[0].Rows[0].Field<string>("author_patronymic");

            return View(model);
        }

        [HttpPost]
        public ActionResult EditAuthor(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Patronymic == null) model.Patronymic = "";
                string commandString = String.Format("update Authors set author_surname = '{0}', author_name = '{1}', author_patronymic = '{2}' where author_id = {3}",
                    model.Surname, model.FirstName, model.Patronymic, model.Id);

                DataSet data = new DataSet();
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);
                    adapter.Fill(data);
                    connection.Close();
                }

                return RedirectToAction("Authors", "Librarian");
            }
            else return View(model);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            AuthorModel model = new AuthorModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAuthor (AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                string commandString;
                if (model.Patronymic != null)
                {
                    commandString = String.Format("insert into Authors (author_surname, author_name, author_patronymic) values ('{0}', '{1}', '{2}')", model.Surname, model.FirstName, model.Patronymic);
                }
                else
                {
                    commandString = String.Format("insert into Authors (author_surname, author_name) values ('{0}', '{1}')", model.Surname, model.FirstName);
                }

                DataSet data = new DataSet();

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);
                    try
                    {
                        adapter.Fill(data);
                    } catch (SqlException ex) { }
                    connection.Close();
                }
                return RedirectToAction("Authors", "Librarian");
            }
            else return View(model);
        }

        public ViewResult SearchAuthors(string symbols)
        {
            List<AuthorModel> authors = new List<AuthorModel>();
            string sqlQuery = String.Format("select * from authors where (author_surname like '%{0}%') or (author_name like '%{0}%') or (author_patronymic like '%{0}%')", symbols);
            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                adapter.Fill(data);
                connection.Close();
            }

            foreach (DataRow dataRow in data.Tables[0].Rows)
            {
                authors.Add(new AuthorModel
                {
                    Id = dataRow.Field<int>("author_id"),
                    Surname = dataRow.Field<string>("author_surname"),
                    FirstName = dataRow.Field<string>("author_name"),
                    Patronymic = dataRow.Field<string>("author_patronymic")
                });
            }

            return View(authors);
        }
        #endregion

        

        #region LibraryControllers

        public ViewResult Libraries()
        {
            string sqlQuery = String.Format("select * from Libraries");
            List<LibraryModel> libraries = LibraryList(sqlQuery);

            return View(libraries);
        }

        public ViewResult SearchLibraries(string symbols)
        {
            string sqlQuery = String.Format("select * from Libraries where library_name like '%{0}%'", symbols);
            List<LibraryModel> libraries = LibraryList(sqlQuery);

            return View(libraries);
        }

        private List<LibraryModel> LibraryList(string sqlQuery)
        {
            List<LibraryModel> libraries = new List<LibraryModel>();

            DataSet data = new DataSet();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                adapter.Fill(data);
                connection.Close();
            }

            foreach(DataRow row in data.Tables[0].Rows)
            {
                libraries.Add(new LibraryModel
                {
                    Id = row.Field<int>("lib_id"),
                    Name = row.Field<string>("library_name"),
                    Adress = row.Field<string>("library_adress")
                });
            }

            return libraries;
        }

        #endregion

        public static List<BookViewModel> BookList(DataSet books)
        {
            List<BookViewModel> lstBooks = new List<BookViewModel>();
            foreach (DataRow dataRow in books.Tables[0].Rows)
            {
                lstBooks.Add(
                   new BookViewModel
                   {
                       Author = new AuthorModel
                       {
                           Id = dataRow.Field<int>("author_id"),
                           Surname = dataRow.Field<string>("author_surname"),
                           FirstName = dataRow.Field<string>("author_name"),
                           Patronymic = dataRow.Field<string>("author_patronymic"),
                       },

                       Book = new BookModel
                       {
                           AuthorId = dataRow.Field<int>("author_id"),
                           Id = dataRow.Field<int>("book_id"),
                           Title = dataRow.Field<string>("title"),
                           DepartmentId = dataRow.Field<int>("department_id")
                       },

                       Department = new DepartmentModel
                       {
                           Id = dataRow.Field<int>("department_id"),
                           Name = dataRow.Field<string>("department_name"),
                           LibraryId = dataRow.Field<int>("lib_id")
                       },

                       Library = new LibraryModel
                       {
                           Id = dataRow.Field<int>("lib_id"),
                           Name = dataRow.Field<string>("library_name"),
                           Adress = dataRow.Field<string>("library_adress")
                       }
                   });
            }

            return lstBooks;
        }
        
        public ActionResult DepartmentsByLibrary(int index)
        {
            DataSet dsDepartments = new DataSet();
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                string commandString = String.Format("select * from Departments where in_library = {0}",
                    index);
                SqlCommand cmd = new SqlCommand(commandString, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsDepartments);

                foreach (DataRow dataRow in dsDepartments.Tables[0].Rows)
                {
                    departments.Add(
                    new DepartmentModel
                    {
                        Id = dataRow.Field<int>("department_id"),
                        Name = dataRow.Field<string>("department_name"),
                        LibraryId = dataRow.Field<int>("in_library")
                    });
                }
            }

            ViewBag.departments = departments;
            return PartialView(departments); 
        }

        public static List <LibraryModel> GetLibraryList()
        {
            List<LibraryModel> libraries = new List<LibraryModel>();
            DataSet dsLibraries = new DataSet();
            using (SqlConnection connection = new SqlConnection (sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Libraries", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsLibraries);
                connection.Close();
            }

            foreach (DataRow dataRow in dsLibraries.Tables[0].Rows)
            {
                libraries.Add(
                    new LibraryModel
                    {
                        Id = dataRow.Field<int>("lib_id"),
                        Name = dataRow.Field<string>("library_name"),
                        Adress = dataRow.Field<string>("library_adress")
                    }
                    );
            }

            return libraries;
        }

        public static List<DepartmentModel> GetDepartmentList(int index)
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            DataSet dsDepartments = new DataSet();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                string commandString = String.Format("select * from Departments where in_library = {0}", index);
                SqlCommand cmd = new SqlCommand(commandString, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dsDepartments);
                connection.Close();
            }

            foreach (DataRow dataRow in dsDepartments.Tables[0].Rows)
            {
                departments.Add(
                    new DepartmentModel
                    {
                        Id = dataRow.Field<int>("department_id"),
                        Name = dataRow.Field<string> ("department_name"),
                        LibraryId = dataRow.Field<int> ("in_library")
                    }
                    );
            }

            return departments;
        }
    }
}
