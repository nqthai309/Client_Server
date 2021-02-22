using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

using CNW_N8_MVC.Models;
using Newtonsoft.Json;

namespace CNW_N8_MVC.Areas.Backend.Controllers
{
    public class BackendHotelController : BaseController
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        private Model1 context = new Model1();
        static int id_Old;
        // GET: BackendHotel
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.hotels = JsonConvert.DeserializeObject<List<hotel>>(client.GetListHotel_BE());
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var model = context.hotels.Find(a);
                    if (model == null)
                    {
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                    }
                    else
                    {
                        id_Old = a;
                        var listLocations = context.locations.Where(l => l.location_name != null).ToList();
                        ViewData["listLocations"] = listLocations;
                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                }
            }

        }
        public int checkAddHotel(string location_id, string hotel_name, string description, string more_imformation, string price, string sell_price)
        {
            if (location_id == "" || hotel_name == "" || description == "" || more_imformation == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                int a = int.Parse(location_id);
                //  var listHotel = context.hotels.Where(h => h.location.id == int.Parse(location_id)).ToList();
                var listHotel = context.hotels.Where(h => h.location_id == a).ToList();

                foreach (var it in listHotel)
                {
                    if (it.hotel_name == hotel_name)
                    {
                        return 0;
                    }
                }
                return 1;

            }
        }
        [HttpPost]
        public ActionResult AddHotel(hotel hotel)
        {
            hotel.image_url = "/Content/img/Group 68.png";
            hotel.detail_header_image_url = "/Content/img/hotel-detail.jpg";
            hotel.more_imformation_image_url = "/Content/img/Group 71.png";
            client.AddHotel_BE(JsonConvert.SerializeObject(hotel));
            //context.hotels.Add(hotel);
            //context.SaveChanges();
            return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
        }

        [HttpPost]
        public ActionResult EditHotel(hotel hotel)
        {
            hotel.image_url = "/Content/img/Group 68.png";
            hotel.detail_header_image_url = "/Content/img/hotel-detail.jpg";
            hotel.more_imformation_image_url = "/Content/img/Group 71.png";
            client.EditHotel_BE(id_Old, JsonConvert.SerializeObject(hotel));
            //context.hotels.Remove(context.hotels.Find(id_Old));
            //context.hotels.Add(hotel);
            //context.SaveChanges();


            return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
        }


        public ActionResult DeleteHotel(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var result = context.hotels.Find(a);
                    if (result == null)
                    {
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                    }
                    else
                    {
                        client.DeleteHotel_BE(int.Parse(id));
                        //context.hotels.Remove(result);
                        //context.SaveChanges();
                        return RedirectToAction("List", "BackendHotel", new { area = "Backend" });

                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHotel", new { area = "Backend" });
                }
            }

        }

        public int checkEditHotel(string location_id, string hotel_name, string description, string more_imformation, string price, string sell_price)
        {
            if (location_id == "" || hotel_name == "" || description == "" || more_imformation == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.hotels.Where(h => h.hotel_name == hotel_name).FirstOrDefault();
                var hotel_old = context.hotels.Find(id_Old);

                if (result == null || hotel_old.hotel_name == hotel_name)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}