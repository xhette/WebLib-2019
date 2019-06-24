using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLib.Models;
using WebLib.Models.Repositories;
using WebLib.Models.Repositories.CompositeModels.Books;
using WebLib.Models.Repositories.CompositeModels.Departments;
using WebLib.Models.Repositories.CompositeModels.Issues;

namespace WebLib.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
                return View();
        }

        #region BooksControllers

            public ViewResult Books()
            {
                return View(BookRepository.SelectAll());
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
            public ActionResult EditBook(BookEditModel model)
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                        BookRepository.Edit(model);
                    }
                    catch (SqlException ex)
                    {

                    }

                    return RedirectToAction("Books", "Admin");

                }
                else
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


                    return RedirectToAction("Books", "Admin");
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
                return RedirectToAction("Books", "Admin");
            }
            #endregion
        
        #region AuthorsControllers

            public ViewResult Authors()
            {
                return View(AuthorRepository.SelectAll());
            }

            public ActionResult DeleteAuthor(int Id)
            {
                try
                {
                    AuthorRepository.Delete(Id);
                }
                catch (SqlException ex) { }

                return RedirectToAction("Authors", "Admin");
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
                    }
                    catch (SqlException ex) { }

                    return RedirectToAction("Authors", "Admin");
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
            public ActionResult AddAuthor(AuthorModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        AuthorRepository.Add(model);
                    }
                    catch (SqlException ex) { }

                    return RedirectToAction("Authors", "Admin");
                }
                else return View(model);
            }

            //partialView
            public ViewResult SearchAuthors(string symbols)
            {
                return View(AuthorRepository.SelectBySearch(symbols));
            }
        #endregion

        #region DepartmentsControllers

        public ViewResult Departments()
        {
            return View(DepartmentRepository.SelectViewAll());
        }

        //partialView
        public ViewResult SearchDepartments(string symbols)
        {
            return View(DepartmentRepository.SelectViewBySearch(symbols));
        }

        //partialView
        public ViewResult DepartmentsByLibrary (int id)
        {
            return View(DepartmentRepository.SelectByLibrary(id));
        }

        [HttpGet]
        public ViewResult EditDepartment (int id)
        {
            DepartmentEditModel model = DepartmentRepository.Edit(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDepartment (DepartmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepartmentRepository.Edit(model);
                } catch (SqlException ex) { }

                return RedirectToAction("Departments", "Admin");
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult AddDepartment()
        {
            DepartmentEditModel model = new DepartmentEditModel
            {
                Department = new DepartmentModel(),
                Libraries = new SelectList(LibraryRepository.SelectAll(), "Id", "Name", 1)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddDepartment (DepartmentEditModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    DepartmentRepository.Add(model);
                }
                catch (SqlException ex) { }

                return RedirectToAction("Departments", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteDepartment (int id)
        {
            try
            {
                DepartmentRepository.Delete(id);
            }
            catch (SqlException ex) { }

            return RedirectToAction("Departments", "Admin");
        }

        #endregion

        #region LibrariesControllers

        public ViewResult Libraries()
            {
                return View(LibraryRepository.SelectAll());
            }

            public ViewResult SearchLibraries(string symbols)
            {
                return View(LibraryRepository.SelectBySearch(symbols));
            }

            [HttpGet]
            public ViewResult EditLibrary(int id)
            {
                return View(LibraryRepository.Edit(id));
            }

            [HttpPost]
            public ActionResult EditLibrary(LibraryModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        LibraryRepository.Edit(model);
                    }
                    catch (SqlException ex) { }

                    return RedirectToAction("Libraries", "Admin");
                }
                else
                {
                    return View(model);
                }
            }

            [HttpGet]
            public ViewResult AddLibrary()
            {
                LibraryModel model = new LibraryModel();
                return View(model);
            }
            
        [HttpPost]
        public ActionResult AddLibrary (LibraryModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    LibraryRepository.Add(model);
                }
                catch (SqlException ex) { }

                return RedirectToAction("Libraries", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteLibrary (int id)
        {
            LibraryRepository.Delete(id);
            return RedirectToAction("Libraries", "Admin");
        }

        #endregion

        #region DeliveriesRepository

        public ViewResult Deliveries()
        {
            return View(DeliveryRepository.ShowAll());
        }

        [HttpGet]
        public ViewResult EditDelivery(int id)
        {
            DeliveryEditModel model = DeliveryRepository.Edit(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDelivery (DeliveryEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DeliveryRepository.Edit(model);

                }
                catch (SqlException ex) { }

                return RedirectToAction("Deliveries", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult AddDelivery()
        {
            DeliveryEditModel model = DeliveryRepository.Add();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDelivery (DeliveryEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DeliveryRepository.Add(model);

                }
                catch (SqlException ex) { }

                return RedirectToAction("Deliveries", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteDelivery (int id)
        {
            try
            {
                DeliveryRepository.Delete(id);

            }
            catch (SqlException ex) { }

            return RedirectToAction("Deliveries", "Admin");
        }

        #endregion

        #region IssuesControllers

        public ViewResult Issues()
        {
            return View(IssueRepository.SelectAll());
        }

        public ViewResult ExpiredIssues()
        {
            return View(IssueRepository.SelectExpired());
        }

        [HttpGet]
        public ViewResult AddIssue()
        {
            return View(IssueRepository.Add());
        }

        [HttpPost]
        public ActionResult AddIssue(IssueEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IssueRepository.Add(model);

                }
                catch (SqlException ex) { }

                return RedirectToAction("Issues", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult EditIssue (int id)
        {
            return View(IssueRepository.Edit(id));
        }

        [HttpPost]
        public ActionResult EditIssue (IssueEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IssueRepository.Edit(model);

                }
                catch (SqlException ex) { }

                return RedirectToAction("Issues", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteIssue (int id)
        {
            try
            {
                IssueRepository.Delete(id);

            }
            catch (SqlException ex) { }

            return RedirectToAction("Issues", "Admin");
        }

        #endregion


        #region ShopsControllers

        public ViewResult Shops()
        {
            return View(ShopRepository.SelectAll());
        }

        //partialView
        public ViewResult SearchShops (string symbols)
        {
            return View(ShopRepository.SelectBySearch(symbols));
        }

        [HttpGet]
        public ViewResult AddShop()
        {
            ShopModel model = new ShopModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddShop (ShopModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ShopRepository.Add(model);
                } catch (SqlException ex) { }

                return RedirectToAction("Shops", "Admin");
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult EditShop (int id)
        {
            return View(ShopRepository.Edit(id));
        }

        [HttpPost]
        public ActionResult EditShop (ShopModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ShopRepository.Edit(model);
                }
                catch (SqlException ex) { }

                return RedirectToAction("Shops", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteShop (int id)
        {
            try
            {
                ShopRepository.Delete(id);
            }
            catch (SqlException ex) { }

            return RedirectToAction("Shops", "Admin");
        }

        #endregion

        #region ReadersControllers

        public ViewResult Readers()
        {
            return View(ReaderRepository.SelectAll());
        }

        public ViewResult SearchReaders (string symbols)
        {
            return View(ReaderRepository.SelectBySearch(symbols));
        }

        public ViewResult Deptors()
        {
            return View(ReaderRepository.SelectDeptors());
        }

        [HttpGet]
        public ViewResult AddReader()
        {
            return View(ReaderRepository.Add());
        }

        [HttpPost]
        public ActionResult AddReader(ReaderModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReaderRepository.Add(model);
                } catch (SqlException ex) { }

                return RedirectToAction("Readers", "Admin");
            } else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ViewResult EditReader (int id)
        {
            return View(ReaderRepository.Edit(id));
        }

        [HttpPost]
        public ActionResult EditReader (ReaderModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ReaderRepository.Edit(model);
                }
                catch (SqlException ex) { }

                return RedirectToAction("Readers", "Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteReader(int id)
        {
            try
            {
                ReaderRepository.Delete(id);
            }
            catch (SqlException ex) { }

            return RedirectToAction("Readers", "Admin");
        }

        #endregion

    }
}


