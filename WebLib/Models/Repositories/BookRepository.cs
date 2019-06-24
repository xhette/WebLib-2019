using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using WebLib.Models.Repositories.CompositeModels.Books;

namespace WebLib.Models.Repositories
{
    public class BookRepository
    {
        private static string getBookListQuery = String.Format
            ("select * from (Authors join (Books join (Departments join Libraries on in_library = lib_id) on department_id = department) on author_id = author) ");

        public static BookViewModel DataToViewModel (DataRow row)
        {
            BookViewModel book = new BookViewModel
            {
                Author = new AuthorModel
                {
                    Id = row.Field<int>("author_id"),
                    Surname = row.Field<string>("author_surname"),
                    FirstName = row.Field<string>("author_name"),
                    Patronymic = row.Field<string>("author_patronymic")
                },

                Book = new BookModel
                {
                    Id = row.Field<int>("book_id"),
                    AuthorId = row.Field<int>("author"),
                    Title = row.Field<string>("title"),
                    DepartmentId = row.Field<int>("department")
                },

                Department = new DepartmentModel
                {
                    Id = row.Field<int>("department_id"),
                    Name = row.Field<string>("department_name"),
                    LibraryId = row.Field<int>("in_library")
                },

                Library = new LibraryModel
                {
                    Id = row.Field<int>("lib_id"),
                    Name = row.Field<string>("library_name"),
                    Adress = row.Field<string>("library_adress")
                }
            };

            return book;
        }

        public static BookModel DataToModel (DataRow row)
        {
            BookModel book = new BookModel
            {
                Id = row.Field<int>("book_id"),
                AuthorId = row.Field<int>("author"),
                Title = row.Field<string>("title"),
                DepartmentId = row.Field<int>("department")
            };

            return book;
        }
        
        public static List<BookModel> Books(string query)
        {
            List<BookModel> books = new List<BookModel>();
            DataSet data = DbContext.DbConnection(query);

            foreach (DataRow row in data.Tables[0].Rows)
            {
                books.Add(DataToModel(row));
            }

            return books;
        }

        public static List<BookModel> AllBooks()
        {
            return Books("select * from Books where department is not null");
        }

        public static List<BookModel> AllBooksByAuthor(int id)
        {
            string query = String.Format("select * from Books where author = {0} and department is not null", id);
            return Books(query);
        }

        public static List<BookViewModel> AllBooksFromDeliveries()
        {
            string query = string.Format("select * from (Authors join Books on author_id = author) where department is null");
            return BookList(query);
        }

        public static List<BookViewModel> BookList(string sqlQuery)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            DataSet data = DbContext.DbConnection(sqlQuery);

            foreach (DataRow row in data.Tables[0].Rows)
            {
                books.Add(DataToViewModel(row));
            }

            return books;
        }

        public static List<BookViewModel> SelectAll()
        {
            List<BookViewModel> books = BookList(getBookListQuery);
            return books;
        }

        public static List<BookViewModel> SelectBySearch(string symbols)
        {
            string sqlQuery = String.Format (getBookListQuery + String.Format("where title like '%{0}%' and department is not null", symbols));
            List<BookViewModel> books = BookList(sqlQuery);
            return books;
        }

        public static List<BookViewModel> SelectByAuthor(int authorId)
        {
            string sqlQuery = String.Format(getBookListQuery + String.Format("where author = {0} and department is not null", authorId));
            List<BookViewModel> books = BookList(sqlQuery);
            return books;
        }

        public static List<BookViewModel> SelectByDepartment (int departmentId)
        {
            string sqlQuery = String.Format(getBookListQuery + String.Format("where department = {0}", departmentId));
            List<BookViewModel> books = BookList(sqlQuery);
            return books;
        }

        public static BookEditModel Edit(int id)
       {
            DataRow selectBook = DbContext.DbConnection(
                String.Format(getBookListQuery + String.Format("where book_id = {0}", id)))
                .Tables[0].Rows[0];


            BookEditModel model = new BookEditModel
            {
                Author = AuthorRepository.DataToModel(selectBook),
                Book = DataToModel(selectBook),
                SelectedDepartmentId = DepartmentRepository.DataToModel(selectBook).Id,
                SelectedLibraryId = LibraryRepository.DataToModel(selectBook).Id
            };


            List<DepartmentModel> departments = DepartmentRepository.SelectByLibrary(model.SelectedLibraryId);
            model.Departments = new SelectList(departments, "Id", "Name", model.SelectedDepartmentId);

            List<LibraryModel> libraries = LibraryRepository.SelectAll();
            model.Libraries = new SelectList(libraries, "Id", "Name", model.SelectedLibraryId);

            return model;
       }

        public static void Edit(BookEditModel model)
        {
            string cmdString = String.Format("exec EditBook {0}, '{1}', '{2}', '{3}', '{4}', {5}",
                  model.Book.Id, model.Author.Surname, model.Author.FirstName, model.Author.Patronymic, model.Book.Title, model.SelectedDepartmentId);
            DataSet data = DbContext.DbConnection(cmdString);

        }

        public static void Add(BookEditModel model)
        {
            string commandString = String.Format("exec AddBook '{0}', '{1}', '{2}', '{3}', {4}",
                       model.Author.Surname, model.Author.FirstName, model.Author.Patronymic, model.Book.Title, model.SelectedDepartmentId);
            DataSet data = DbContext.DbConnection(commandString);
        }

        public static void Delete(int id)
        {
            string sqlQuery = String.Format("delete from Books where book_id = {0}", id);
            DataSet data = DbContext.DbConnection(sqlQuery);
        }
    }
}
