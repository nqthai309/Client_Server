using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNW_N8_MVC.Models;
using Newtonsoft.Json;

namespace CNW_N8_MVC.Controllers
{
    public class LocationController : Controller
    {
        private Model1 context = new Model1();
        IPagedList<hotel> model;
        int quantity;
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
            setUsername();
            
            return View();
        }
        public ActionResult HotelList(string locationName, int? page)
        {
            setUsername();
            ViewData["locationName"] = locationName;
            var model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetListHotelByLocation(locationName)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();

            var optionList = JsonConvert.DeserializeObject<List<location>>(client.FrontEndGetListLocation());
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
       
        
        public ActionResult HomestayList(string locationName, int? page)
        {
            setUsername();
            ViewData["locationName"] = locationName;
            var model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetListHomestayByLocation(locationName)).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();

            var optionList = JsonConvert.DeserializeObject<List<location>>(client.FrontEndGetListLocation());
            ViewData["optionList"] = optionList;

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }
      
        
    }
}