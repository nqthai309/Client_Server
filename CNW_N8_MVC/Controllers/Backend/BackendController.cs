using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNW_N8_MVC.Models;

namespace CNW_N8_MVC.Controllers.Backend
{
    public class BackendController : Controller
    {
        private Model1 context = new Model1();
        // GET: Backend
        public ActionResult Index()
        {
            if(Session["LoginBackend"] == null)
            {
                return RedirectToAction("Login", "Backend");
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
            if(result != null)
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

            return RedirectToAction("List", "BackendUser");
        }
    }
}