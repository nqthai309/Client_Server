using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNW_N8_MVC.Models;
using Newtonsoft.Json;

namespace CNW_N8_MVC.Controllers
{
    public class UserController : Controller
    {
        Model1 context = new Model1();
        public static int idAccount = 0;
        public static string userName = null;
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            
            return View();
        }
        
        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session["CartSession"] = null;
            idAccount = 0;
            userName = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult LoginCenter(user acc)
        {
            var result = JsonConvert.DeserializeObject<user>(client.FrontEndLogin(acc.username,acc.password));
            if (result != null)
            {
                    Session["Login"] = result;
                    idAccount = result.id;
                    userName = result.username.ToString();
                    ViewData["username"] = result.username.ToString();
                    return RedirectToAction("Index", "Home");
            }
            return View();
            
        }

        public int checkMK(string user, string pass)
        {
            var result = JsonConvert.DeserializeObject<user>(client.FrontEndLogin(user, pass));
            if (result != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int checkDangKy(string user, string pass)
        {
            if(user == "" || pass == "")
            {
                return -1;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<user>(client.FrontEndFindUserByUsername(user));
                if (result != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        public int checkNewPassword(string nowPassword, string newPassword, string NewPassword2)
        {
            var result = JsonConvert.DeserializeObject<user>(client.FrontEndFindUserById(idAccount));
            if(result.password == nowPassword && newPassword != "" && NewPassword2 != "")
            {
                if(newPassword == NewPassword2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCenter(user acc)
        {
            acc.role_id = 1;
            client.FrontEndRegister(JsonConvert.SerializeObject(acc));
            return RedirectToAction("Login","User");

        }

        public ActionResult Config()
        {
            if (Session["Login"] == null)
            {
                return View("Login");
            }
            else
            {
                var acc = JsonConvert.DeserializeObject<user>(client.FrontEndFindUserById(idAccount));
                //var acc = Session["Login"];
                ViewData["username"] = userName;
                //Session["Login"] = acc;
                ViewData["acc"] = acc;
                return View();
            }
            
        }

        public ActionResult Booking()
        {
            Cart cart;
            ViewData["username"] = userName;
            if (Session["Login"] == null)
            {
                return View("Login");
            }
            else
            {
                cart = (Cart)Session["CartSession"];
                if(cart == null)
                {
                    cart = new Cart();
                }
                return View(cart);
            }
        }

        [HttpPost]
        public ActionResult UserChanges(user acc)
        {
            var obj = JsonConvert.DeserializeObject<user>(client.FrontEndFindUserById(idAccount));
            obj.full_name = acc.full_name;
            obj.phone = acc.phone;
            obj.email = acc.email;
            obj.address = acc.address;
            string json = JsonConvert.SerializeObject(obj);
            client.FrontEndUpdateUserInfo(idAccount, json);
            idAccount += 1;
            //Session["Login"] = obj;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult PasswordChanges(string password, string newPassword1, string newPassword2)
        {
            var obj = JsonConvert.DeserializeObject<user>(client.FrontEndFindUserById(idAccount));
            if (password == "" || newPassword1 == "" || newPassword2 == "")
            {
                //Điền Thiếu thông tin//
                return RedirectToAction("Config", "User");
            }
            else
            {
              
                if(obj.password == password)
                {
                    if (newPassword1 == newPassword2)
                    {
                        client.FrontEndChangePassword(obj.id, newPassword1);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        //Thông tin chưa chính xác
                        return RedirectToAction("Config", "User");
                    }
                }
                else
                {
                    //Thông tin chưa chính xác
                    return RedirectToAction("Config", "User");
                }
            }
            
        }

        public ActionResult RemoveLine(string id,string checkin, string status_checking)
        {
            int a;
            bool check = int.TryParse(id, out a);
            if(check == true)
            {
                if (status_checking == "hotel")
                {
                    var result = JsonConvert.DeserializeObject<user>(client.FrontEndFindHotelById(a));
                    var product = new Product(result.id.ToString(), "hotel", checkin);
                    var cart = (Cart)Session["CartSession"];
                    if(cart != null)
                    {
                        cart.RemoveLineProduct(product);
                        return RedirectToAction("Booking", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if(status_checking == "homestay")
                {
                    var result = JsonConvert.DeserializeObject<user>(client.FrontEndFindHomestayById(a));
                    var product = new Product(result.id.ToString(), "homestay", checkin);
                    var cart = (Cart)Session["CartSession"];
                    if (cart != null)
                    {
                        cart.RemoveLineProduct(product);
                        return RedirectToAction("Booking", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public ActionResult ThanhToan()
        {
            var cart = (Cart)Session["CartSession"];
            var acc = context.users.Find(idAccount);
            
            if(cart == null || cart.lines.Count() == 0 || acc == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                foreach(var it in cart.lines)
                {
                    if(it.Product.Status_checking == "hotel")
                    {
                        DateTime checkin = Convert.ToDateTime(it.Product.Checkin);
                        DateTime checkout = Convert.ToDateTime(it.Product.Checkout);
                        TimeSpan t = checkout - checkin;

                        var ht_booking = new hotel_booking();
                        ht_booking.customer_address = acc.address;
                        ht_booking.customer_email = acc.email;
                        ht_booking.customer_name = acc.full_name;
                        ht_booking.customer_phone = acc.phone;
                        ht_booking.user_id = acc.id;

                        ht_booking.hotel_id = int.Parse(it.Product.Id);
                        ht_booking.from_date = checkin;
                        ht_booking.to_date = checkout;

                        
                        ht_booking.selectDichVu = it.SelectDichVu;
                        ht_booking.thanhTienDichVu = it.ThanhTienDichVu;
                        ht_booking.status_check = "Đang Xử Lý";
                        ht_booking.total_price = ((int)t.TotalDays * int.Parse(it.Product.Sell_price));
                        client.FrontEndAddHotelBooking(JsonConvert.SerializeObject(ht_booking));

                        

                    }
                    else if(it.Product.Status_checking == "homestay")
                    {
                        DateTime checkin = Convert.ToDateTime(it.Product.Checkin);
                        DateTime checkout = Convert.ToDateTime(it.Product.Checkout);
                        TimeSpan t = checkout - checkin;

                        var hstay_booking = new homestay_booking();
                        hstay_booking.customer_address = acc.address;
                        hstay_booking.customer_email = acc.email;
                        hstay_booking.customer_name = acc.full_name;
                        hstay_booking.customer_phone = acc.phone;
                        hstay_booking.user_id = acc.id;

                        hstay_booking.homestay_id = int.Parse(it.Product.Id);
                        hstay_booking.from_date = checkin;
                        hstay_booking.to_date = checkout;

                        
                        hstay_booking.selectDichVu = it.SelectDichVu;
                        hstay_booking.thanhTienDichVu = it.ThanhTienDichVu;
                        hstay_booking.status_check = "Đang Xử Lý";
                        hstay_booking.total_price = ((int)t.TotalDays * int.Parse(it.Product.Sell_price));
                        client.FrontEndAddHomestayBooking(JsonConvert.SerializeObject(hstay_booking));


                    }   
                }
                cart.Clear();
                return RedirectToAction("Index", "Home");
            }
            
        }
        //[HttpDelete]
        //public ActionResult DeleteItem(int id, string status_check)
        //{
        //    var cart = (Cart)Session["CartSession"];
        //    var list = cart.lines.ToList();
        //    try
        //    {
        //        foreach(var it  in list)
        //        {
        //            if(it.Product.Id == id.ToString() && it.Product.Status_checking == status_check)
        //            {
        //                cart.RemoveLineProduct(it.Product);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return RedirectToAction("Booking", "User");
        //}
    }
}