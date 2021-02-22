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
    public class BackendHomestayController : BaseController
    {
        private Model1 context = new Model1();
        static int id_old;
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        // GET: BackendHomestay
        public ActionResult List()
        {
            dynamic model = new ExpandoObject();
            model.homestays = JsonConvert.DeserializeObject<List<homestay>>(client.GetListHomestay_BE());
            return View(model);
        }

        public ActionResult Add()
        {
            var listLocation = context.locations.ToList();
            ViewData["listLocation"] = listLocation;
            return View();
        }

        [HttpPost]
        public ActionResult AddHomestay(homestay homeStay)
        {
            homeStay.detail_header_image_url = "/Content/img/Group 65.png";
            homeStay.image_url = "/Content/img/Group 65.png";
            homeStay.more_imformation = "/Content/img/Group 65.png";
            homeStay.description = "This is Description";
            client.AddHomestay_BE(JsonConvert.SerializeObject(homeStay));
            //context.homestays.Add(homeStay);
            //context.SaveChanges();
            return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
        }
        [HttpPost]
        public int checkAddHomeStay(string homestay_name, string location_id, string price, string sell_price)
        {
            if (homestay_name == "" || location_id == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.homestays.Where(u => (u.homestay_name == homestay_name)).FirstOrDefault();
                if (result == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var model = context.homestays.Find(a);
                    if (model == null)
                    {
                        return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                    }
                    else
                    {
                        id_old = a;
                        //lay danh sach location sang ben view Edit//

                        var listLocation = context.locations.ToList();
                        ViewData["listLocation"] = listLocation;

                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                }
            }

        }


        [HttpPost]
        public ActionResult EditHomestay(homestay homeStay)
        {
            client.EditHomestay_BE(id_old, JsonConvert.SerializeObject(homeStay));
            //var result = context.homestays.Find(id_old);
            //context.homestays.Remove(result);
            //context.homestays.Add(homeStay);
            //context.SaveChanges();
            return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
        }
        public int checkEditHomestay(string homestay_name, string location_id, string price, string sell_price)
        {
            if (homestay_name == "" || location_id == "" || price == "" || sell_price == "")
            {
                return -1;
            }
            else
            {
                var result = context.homestays.Where(u => (u.homestay_name == homestay_name)).FirstOrDefault();
                var userOld = context.homestays.Find(id_old);

                if (result == null || (result.homestay_name == userOld.homestay_name))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }


        public ActionResult DeleteHomestay(string id)
        {
            if (id == null)
            {
                return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
            }
            else
            {
                int a;
                bool check = int.TryParse(id.ToString(), out a);
                if (check == true)
                {
                    var result = context.homestays.Find(a);
                    if (result == null)
                    {
                        return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                    }
                    else
                    {
                        client.DeleteHomestay_BE(int.Parse(id));
                        //context.homestays.Remove(result);
                        //context.SaveChanges();
                        return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                    }

                }
                else
                {
                    return RedirectToAction("List", "BackendHomestay", new { area = "Backend" });
                }
            }

        }

        public ActionResult LogoutBackend()
        {
            Session["LoginBackend"] = null;

            return RedirectToAction("Index", "Home", new { area = "Backend" });
        }
    }
}