using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;
using CNW_N8_MVC.Controllers;

namespace CNW_N8_MVC.Areas.Backend.Controllers
{
    public class BackendHomeController : Controller
    {
        // GET: Backend/Home
        private Model1 context = new Model1();
        // GET: Backend
        public ActionResult Index()
        {
            if (Session["LoginBackend"] == null)
            {
                return RedirectToAction("Login", "BackendHome", new { area = "Backend" });
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {

            return View();
        }
        public int checkLoginBackend(string user, string pass)
        {
            var result = context.users.Where(a => (a.username == user && a.password == pass && a.role_id == 0)).FirstOrDefault();
            if (result != null)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


        [HttpGet]
        public ActionResult LoginCenter(user acc)
        {
            Session["LoginBackend"] = acc;

            return RedirectToAction("List", "BackendUser", new { area = "Backend" });
        }
    }
}