using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebLib.Models;
using WebLib.Models.Repositories;
using WebLib.Models.Repositories.CompositeModels;

namespace WebLib.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Authorize (UserRoleModel model)
        {
            if (ModelState.IsValid)
            {
                DataSet data = DbContext.DbConnection(String.Format("select * from Users where user_name = {0}", model.User.Login));
                if (data.Tables[0].Rows.Count != 0)
                {
                    int accountId = model.User.Id;
                    HttpContext.Session.SetInt32("accountId", accountId);

                    if (model.Role.RoleId == 1)
                    {
                        return RedirectToAction("Index", "");
                    }
                    else if (model.Role.RoleId == 2)
                    {
                        return RedirectToAction("Index", "");
                    }
                    else if (model.Role.RoleId == 3)
                    {
                        return RedirectToAction("Index", "");
                    }
                    else if (model.Role.RoleId == 4)
                    {
                        return RedirectToAction("Index", "");
                    }
                    else if (model.Role.RoleId == 5)
                    {
                        return RedirectToAction("Index", "");
                    }
                    else return View(model);
                }
                else return View(model);
            }
            else return View(model);
        }
    }
}
