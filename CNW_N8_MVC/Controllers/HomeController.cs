using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;
using Newtonsoft.Json;

namespace CNW_N8_MVC.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private void setUsername()
        {
            if (Session["Login"] == null)
            {
                ViewData["username"] = null;
            }
            else
            {
                ViewData["username"] = UserController.userName;
            }
        }
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.hotels = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetListHotel());
            model.homestays = JsonConvert.DeserializeObject<List<homestay>>(client.FrontEndGetListHomestay());
            model.locations = JsonConvert.DeserializeObject<List<location>>(client.FrontEndGetListLocation());
            setUsername();
            return View(model);
        }
    }
}