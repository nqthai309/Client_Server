using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using CNW_N8_MVC.Models;
using Newtonsoft.Json;

namespace CNW_N8_MVC.Controllers
{
    public class HotelController : Controller
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
        public ActionResult List(int? page)
        {

            //int page1 = page.Value;
            //dynamic model = new ExpandoObject();
            setUsername();
            var optionList = JsonConvert.DeserializeObject<List<location>>(client.FrontEndOpitionList());
            //var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;

            var model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetListHotels(page)).ToPagedList(page ?? 1, 9);
            //model.hotels = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetListHotels(page)).ToPagedList(page ?? 1, 9);
            //var model = context.hotels.OrderByDescending(h => h.id).ToPagedList(page ?? 1, 9);
            ViewData["count"] = model.Count.ToString();

            var minPrice = JsonConvert.DeserializeObject<int>(client.FrontEndMinPrice());
            //var minPrice = context.hotels.Min(h => h.sell_price);

            var maxPrice = JsonConvert.DeserializeObject<int>(client.FrontEndMaxPrice());
            //var maxPrice = context.hotels.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();

            return View(model);
        }


        [HttpGet]
        public ActionResult SearchEngine(int? page)
        {

            setUsername();
            var priceRange = Request["priceRange"];
            var locationSelect = Request["locationSelect"];
            var txtSearch = Request["txtSearch"];

            var optionList = JsonConvert.DeserializeObject<List<location>>(client.FrontEndOpitionList());
            //var optionList = context.locations.Where(o => o.id != null).ToList();
            ViewData["optionList"] = optionList;
            if (priceRange == "Dưới 300.000VNĐ")
            {

                //model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price < 300000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
                model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndSearchEngine_Price1(page, txtSearch, locationSelect)).ToPagedList(page ?? 1, 9);

            }
            if (priceRange == "300.000- 500.000VNĐ")
            {

                model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndSearchEngine_Price2(page, txtSearch, locationSelect)).ToPagedList(page ?? 1, 9);

                //model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price >= 300000 && h.sell_price <500000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }
            if (priceRange == "500.000- 1.000.000VNĐ")
            {

                model = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndSearchEngine_Price3(page, txtSearch, locationSelect)).ToPagedList(page ?? 1, 9);
                //model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price >= 500000 && h.sell_price < 1000000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            }

            var minPrice = model.Min(h => h.sell_price);
            var maxPrice = model.Max(h => h.sell_price);
            ViewData["minPrice"] = minPrice.ToString();
            ViewData["maxPrice"] = maxPrice.ToString();
            ViewData["count"] = model.Count.ToString();
            ViewData["priceRange"] = priceRange.ToString();
            ViewData["locationSelect"] = locationSelect.ToString();
            ViewData["txtSearch"] = txtSearch.ToString();


            return View("List", model);
        }
        public ActionResult Detail(int? id)
        {

            if (id.HasValue)
            {
                setUsername();
                dynamic model = new ExpandoObject();

                model.hotel = JsonConvert.DeserializeObject<hotel>(client.FrontEndGetDetialHotel(id));
                //model.hotels = context.hotels.Where(x => x.id != 0).ToList();
                model.hotels = JsonConvert.DeserializeObject<List<hotel>>(client.FrontEndGetDetialHotels());
                //model.hotel = context.hotels.Where(x => x.id == id).FirstOrDefault();

                //model.dichVu = context.DichVu_HT_HS.Where(x => x.theLoai == "hotel" && x.idHTHS == id).ToList();
                model.dichVu = JsonConvert.DeserializeObject<List<DichVu_HT_HS>>(client.FrontEndGetDichVuHotel(id));
                ViewData["id"] = id.ToString();
                return View(model);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddItemHotel(int id)
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                //var x1 = Request["dvAnSang"];
                
                DateTime checkIn = Convert.ToDateTime(Request["check_in"]);
                DateTime checkOut = Convert.ToDateTime(Request["check_out"]);
                if (checkOut <= checkIn)
                {
                    //Ngày đi lớn hơn ngày về//
                    return RedirectToAction("Detail", "Hotel", new { id = id });
                }
                else
                {
                    TimeSpan t = checkOut - checkIn;
                    quantity = (int)t.TotalDays;
                }
                string selectDichVu = "";
                int thanhTienDichVu = 0;
                //var hotel = context.hotels.Find(id);
                var hotel = JsonConvert.DeserializeObject<hotel>(client.FrontEndAddItemHotel(id));
                var dichVu = JsonConvert.DeserializeObject<List<DichVu_HT_HS>>(client.FrontEndGetDichVuHotel(id));
                foreach (var it in dichVu)
                {
                    if(Request[it.idDichVu] == "1")
                    {
                        selectDichVu += it.tenDichVu + ',';
                        thanhTienDichVu += (int)it.donGiaDichVu;
                    }
                }
                var cart = (Cart)Session["CartSession"];
                if (cart != null)
                {
                    cart.AddItemHotel(hotel, checkIn.ToShortDateString(), checkOut.ToShortDateString(), quantity, selectDichVu, thanhTienDichVu); ;
                }
                else
                {
                    cart = new Cart();
                    cart.AddItemHotel(hotel, checkIn.ToShortDateString(), checkOut.ToShortDateString(), quantity, selectDichVu, thanhTienDichVu);
                    Session["CartSession"] = cart;
                }

                return RedirectToAction("Booking", "User");
            }


        }

        public int checkDate(string checkin, string checkout)
        {
            if (checkin == "" || checkout == "")
            {
                return -1;
            }
            else
            {
                DateTime checkIn = Convert.ToDateTime(checkin);
                DateTime checkOut = Convert.ToDateTime(checkout);

                if (checkOut <= checkIn)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }

            }

        }
    }
}