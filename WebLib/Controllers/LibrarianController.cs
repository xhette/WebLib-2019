using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLib.Models;
using WebLib.Models.Repositories;
using WebLib.Models.Repositories.CompositeModels;
using WebLib.Models.Repositories.CompositeModels.Books;

namespace WebLib.Controllers
{
    public class LibrarianController : Controller
    {
        static string sqlConnectionString = String.Format("Data Source=localhost;Initial Catalog=Library;Integrated Security=True;");

        public IActionResult Index()
        {
            int accountId = (int)HttpContext.Session.GetInt32("accountId");
            UserEmployeeModel model;
            return View(model);
        }

        #region BooksControllers

        public ViewResult Books()
        {
            List<BookViewModel> listBooks = BookRepository.SelectAll();
            ViewBag.listBooks = listBooks;
            return View(listBooks);
        }
        
        //partialView
        public ViewResult SearchBooks(string symbols)
        {

            List<BookViewModel> listBooks = BookRepository.SelectBySearch(symbols);
            ViewBag.listBooks = listBooks;
            return View("SearchBooks", listBooks);
        }

        [HttpGet]
        public ViewResult EditBook(int Id)
        {
           BookEditModel editmodel = BookRepository.Edit(Id);
            return View(editmodel);
        }

        [HttpPost]
        public ActionResult EditBook (BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    BookRepository.Edit(model);
                } catch (Exception ex)
                {

                }

                return RedirectToAction("Books", "Librarian");

            } else
            {
                BookEditModel editmodel = BookRepository.Edit(model.Book.Id);
                return View(editmodel);
            }
        }


        [HttpGet]
        public ViewResult AddBook()
        {
            BookEditModel model = new BookEditModel
            {
                Author = new AuthorModel(),
                Book = new BookModel(),
                Departments = new SelectList(DepartmentRepository.SelectAll(), "Id", "Name", 1),
                Libraries = new SelectList(LibraryRepository.SelectAll(), "Id", "Name", 1)
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBook(BookEditModel model)
        {
            if (ModelState.IsValid)
            {
                    try
                    {
                        BookRepository.Add(model);
                    }
                    catch (SqlException exc)
                    {

                    }
                    
                
                return RedirectToAction("Books", "Librarian");
            }
            else
            {
               return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            BookRepository.Delete(id);
            return RedirectToAction("Books", "Librarian");
        }
        #endregion

      


        #region AuthorsControllers
        public ViewResult Authors()
        {
            return View(AuthorRepository.SelectAll());
        }

        public ActionResult DeleteAuthor (int Id)
        {
            try
            {
                AuthorRepository.Delete(Id);
            } catch (Exception ex) { }

            return RedirectToAction("Authors", "Librarian");
        }

        [HttpGet]
        public ActionResult EditAuthor(int Id)
        {
            AuthorModel model = AuthorRepository.Edit(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditAuthor(AuthorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthorRepository.Edit(model);
                } catch (Exception ex) { }

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
                try
                {
                    AuthorRepository.Add(model);
                } catch (Exception ex) { }

                return RedirectToAction("Authors", "Librarian");
            }
            else return View(model);
        }

        //partialView
        public ViewResult SearchAuthors(string symbols)
        {
            return View(AuthorRepository.SelectBySearch(symbols));
        }
        #endregion

        

        #region LibraryControllers

        public ViewResult Libraries()
        {
            return View(LibraryRepository.SelectAll());
        }

        public ViewResult SearchLibraries(string symbols)
        {
            return View(LibraryRepository.SelectBySearch(symbols));
        }

        #endregion


    }
}
