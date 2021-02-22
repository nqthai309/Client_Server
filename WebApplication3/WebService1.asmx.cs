using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using WebApplication3.Models;

namespace WebApplication3
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Model1 context = new Model1();
        //IPagedList<homestay> model;
        //------------------------THAI----------------------------------
        [WebMethod]
        public string DangNhapAppWinForm(string username, string password)
        {
            var list = context.users.Where(x => x.id != 0).ToList();
            foreach (var item in list)
            {
                if (username == item.username && password == item.password && item.role_id == 0)
                {
                    return JsonConvert.SerializeObject(item);
                }
            }
            return "0";
        }

        [WebMethod]
        public string GetListUser_BE()
        {
            var model = context.users.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(model);
            return json;
        }

        [WebMethod]
        public void EditUser_BE(int id_old, string json)
        {
            user acc = JsonConvert.DeserializeObject<user>(json);
            context.users.Add(acc);
            context.SaveChanges();
            var hotel_bookings = context.hotel_booking.Where(x => x.user_id == id_old).ToList();
            
            var homestay_bookings = context.homestay_booking.Where(x => x.user_id == id_old).ToList();
            

            foreach (var it in hotel_bookings)
            {
                hotel_booking htb = new hotel_booking(acc.id, acc.full_name, acc.email, acc.phone, acc.address, it.hotel_id, it.from_date, it.to_date, it.total_price, it.selectDichVu, it.thanhTienDichVu, "Đang xử lý");
                context.hotel_booking.Add(htb);
                context.SaveChanges();
                context.hotel_booking.Remove(it);
                context.SaveChanges();
            }
            foreach (var it in homestay_bookings)
            {
                homestay_booking hsb = new homestay_booking(acc.id, acc.full_name, acc.email, acc.phone, acc.address, it.homestay_id, it.from_date, it.to_date, it.total_price, it.selectDichVu, it.thanhTienDichVu, "Đang xử lý");
                context.homestay_booking.Add(hsb);
                context.SaveChanges();
                context.homestay_booking.Remove(it);
                context.SaveChanges();
            }
            context.users.Remove(context.users.Find(id_old));
            context.SaveChanges();
        }

        [WebMethod]
        public void AddUser_BE(string json)
        {
            user acc = JsonConvert.DeserializeObject<user>(json);
            context.users.Add(acc);
            context.SaveChanges();
        }

        [WebMethod]
        public void DeleteUser_BE(int id)
        {
            var listHotelBooking = context.hotel_booking.Where(x => x.user_id == id).ToList();
            var listHomestayBooking = context.homestay_booking.Where(x => x.user_id == id).ToList();
            foreach(var it in listHotelBooking)
            {
                context.hotel_booking.Remove(it);
            }
            foreach(var it in listHomestayBooking)
            {
                context.homestay_booking.Remove(it);
            }

            var result = context.users.Find(id);
            context.users.Remove(result);
            context.SaveChanges();
        }

        [WebMethod]
        public string GetListHotel_BE()
        {
            var list = context.hotels.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public void AddHotel_BE(string json)
        {
            var hotel = JsonConvert.DeserializeObject<hotel>(json);
            context.hotels.Add(hotel);
            context.SaveChanges();
        }

        [WebMethod]
        public void EditHotel_BE(int id_old, string json)
        {
            var row_bookings = context.hotel_booking.Where(x => x.hotel_id == id_old).ToList();
            var row_DichVu_HS_HT = context.DichVu_HT_HS.Where(x => x.idHTHS == id_old).ToList();
            var newRows_Booking = row_bookings;
            var newRows_DichVu_HS_HT = row_DichVu_HS_HT;
            foreach (var item in row_bookings)
            {
                context.hotel_booking.Remove(item);
                
            }
            foreach(var item in row_DichVu_HS_HT)
            {
                context.DichVu_HT_HS.Remove(item);
            }
            context.hotels.Remove(context.hotels.Find(id_old));
            var hotel = JsonConvert.DeserializeObject<hotel>(json);
            context.hotels.Add(hotel);
            context.SaveChanges();
            foreach (var item in newRows_Booking)
            {
                item.hotel_id = hotel.id;
                context.hotel_booking.Add(item);
            }
            foreach(var item in newRows_DichVu_HS_HT)
            {
                item.idHTHS = hotel.id;
                context.DichVu_HT_HS.Add(item);
            }
            context.SaveChanges();
        }

        [WebMethod]
        public void DeleteHotel_BE(int id)
        {
            var listBooking = context.hotel_booking.Where(x => x.hotel_id == id).ToList();
            var listDichVu = context.DichVu_HT_HS.Where(x => x.idHTHS == id).ToList();
            foreach(var it in listDichVu)
            {
                context.DichVu_HT_HS.Remove(it);
            }
            foreach (var item in listBooking)
            {
                context.hotel_booking.Remove(item);
            }
            context.SaveChanges();
            context.hotels.Remove(context.hotels.Find(id));
            context.SaveChanges();
        }

        [WebMethod]
        public string GetListHomestay_BE()
        {
            var list = context.homestays.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public void AddHomestay_BE(string json)
        {
            var homeStay = JsonConvert.DeserializeObject<homestay>(json);
            context.homestays.Add(homeStay);
            context.SaveChanges();
        }

        [WebMethod]
        public void EditHomestay_BE(int id_old, string json)
        {
            var row_bookings = context.homestay_booking.Where(x => x.homestay_id == id_old).ToList();
            var row_DichVu_HS_HT = context.DichVu_HT_HS.Where(x => x.idHTHS == id_old).ToList();
            var newRows_DichVu = row_DichVu_HS_HT;
            var newRows = row_bookings;
            foreach(var item in row_DichVu_HS_HT)
            {
                context.DichVu_HT_HS.Remove(item);
            }
            foreach (var item in row_bookings)
            {
                context.homestay_booking.Remove(item);
            }
            context.homestays.Remove(context.homestays.Find(id_old));
            var homeStay = JsonConvert.DeserializeObject<homestay>(json);
            context.homestays.Add(homeStay);
            context.SaveChanges();
            foreach(var it in newRows_DichVu)
            {
                it.idHTHS = homeStay.id;
                context.DichVu_HT_HS.Add(it);
            }
            foreach (var item in newRows)
            {
                item.homestay_id = homeStay.id;
                context.homestay_booking.Add(item);
            }
            context.SaveChanges();
        }

        [WebMethod]
        public void DeleteHomestay_BE(int id)
        {
            var listBooking = context.homestay_booking.Where(x => x.homestay_id == id).ToList();
            var listDichVu = context.DichVu_HT_HS.Where(x => x.idHTHS == id).ToList();
            foreach(var item in listDichVu)
            {
                context.DichVu_HT_HS.Remove(item);
            }
            foreach (var item in listBooking)
            {
                context.homestay_booking.Remove(item);
            }
            context.SaveChanges();
            context.homestays.Remove(context.homestays.Find(id));
            context.SaveChanges();
        }

        [WebMethod]
        public string GetListBooking_BE(string key)
        {
            try
            {
                if (key == "hotel_bookings")
                {
                    var json = JsonConvert.SerializeObject(context.hotel_booking.Where(x => x.id != 0).ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
                if (key == "homestay_bookings")
                {
                    var json = JsonConvert.SerializeObject(context.homestay_booking.Where(x => x.id != 0).ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }
        [WebMethod]
        public string GetListBookingOptional_BE(string key, string status_check)
        {
            try
            {
                if (key == "hotel_bookings" && status_check == "Đang Xử Lý")
                {
                    var json = JsonConvert.SerializeObject(context.hotel_booking.Where(x => x.id != 0 && x.status_check == "Đang Xử Lý").ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
                else if(key == "hotel_bookings" && status_check == "Xác Nhận")
                {
                    var json = JsonConvert.SerializeObject(context.hotel_booking.Where(x => x.id != 0 && x.status_check == "Xác Nhận").ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
                else if (key == "homestay_bookings" && status_check == "Đang Xử Lý")
                {
                    var json = JsonConvert.SerializeObject(context.homestay_booking.Where(x => x.id != 0 && x.status_check == "Đang Xử Lý").ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
                else if(key == "homestay_bookings" && status_check == "Xác Nhận")
                {
                    var json = JsonConvert.SerializeObject(context.homestay_booking.Where(x => x.id != 0 && x.status_check == "Xác Nhận").ToList(), Formatting.Indented, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return json;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }

        //------------------------THAI----------------------------------
        //------------------------TUNG----------------------------------
        //user/home
        [WebMethod]
        public string FrontEndGetListHomestay()
        {
            var list = context.homestays.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetListHotel()
        {
            var list = context.hotels.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }


        [WebMethod]
        public string FrontEndFindHomestayById(int id)
        {
            var homestay = context.homestays.Where(x => x.id == id).FirstOrDefault();
            string json = JsonConvert.SerializeObject(homestay, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndFindHotelById(int id)
        {
            var hotel = context.hotels.Where(x => x.id == id).FirstOrDefault();
            string json = JsonConvert.SerializeObject(hotel, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetListLocation()
        {
            var list = context.locations.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetListHomestayByLocation(string locationName)
        {
            var list = context.homestays.OrderByDescending(m => m.id).Where(h => h.location.location_name == locationName).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetListHotelByLocation(string locationName)
        {
            var list = context.hotels.OrderByDescending(m => m.id).Where(h => h.location.location_name == locationName).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndLogin(string username, string password)
        {
            var result = context.users.Where(a => (a.username == username && a.password == password)).FirstOrDefault();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndFindUserById(int id)
        {
            var result = context.users.Where(a => (a.id == id)).FirstOrDefault();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndFindUserByUsername(string username)
        {
            var result = context.users.Where(a => (a.username == username)).FirstOrDefault();
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }


        [WebMethod]
        public void FrontEndRegister(string json)
        {
            var user = JsonConvert.DeserializeObject<user>(json);
            context.users.Add(user);
            context.SaveChanges();
        }

        [WebMethod]
        public void FrontEndUpdateUserInfo(int id, string json)
        {
            user acc = JsonConvert.DeserializeObject<user>(json);
            var result = context.users.Find(id);
            context.users.Remove(result);
            context.users.Add(acc);
            context.SaveChanges();
        }

        [WebMethod]
        public void FrontEndChangePassword(int id, string password)
        {
            var result = context.users.Find(id);
            if (result != null)
            {
                result.password = password;
                context.SaveChanges();
            }
        }

        [WebMethod]
        public void FrontEndAddHotelBooking(string json)
        {
            var hotelBooking = JsonConvert.DeserializeObject<hotel_booking>(json);
            context.hotel_booking.Add(hotelBooking);
            context.SaveChanges();
        }

        [WebMethod]
        public void FrontEndAddHomestayBooking(string json)
        {
            var homestayBooking = JsonConvert.DeserializeObject<homestay_booking>(json);
            context.homestay_booking.Add(homestayBooking);
            context.SaveChanges();
        }

        [WebMethod]
        public void DeleteHotelBooking_BE(int id)
        {
            var result = context.hotel_booking.Where(x => x.id == id).SingleOrDefault();
            context.hotel_booking.Remove(result);
            context.SaveChanges();
        }

        [WebMethod]
        public void DeleteHomestayBooking_BE(int id)
        {
            var result = context.homestay_booking.Where(x => x.id == id).SingleOrDefault();
            context.homestay_booking.Remove(result);
            context.SaveChanges();
        }

        [WebMethod]
        public void ConfirmHotelBooking_BE(int id)
        {
            var result = context.hotel_booking.Where(x => x.id == id).SingleOrDefault();
            result.status_check = "Xác Nhận";
            context.SaveChanges();
        }

        [WebMethod]
        public void ConfirmHomestayBooking_BE(int id)
        {
            var result = context.homestay_booking.Where(x => x.id == id).SingleOrDefault();
            result.status_check = "Xác Nhận";
            context.SaveChanges();
        }
        //------------------------TUNG----------------------------------
        //------------------------THANG----------------------------------
        //hotel

        [WebMethod]
        public string FrontEndGetListHotels(int? page)
        {
            //var model = context.homestays.Where(x => x.id != 0).ToList();
            var model = context.hotels.OrderByDescending(h => h.id).ToPagedList(page ?? 1, 9);
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }



        [WebMethod]
        public string FrontEndGetDetialHotel(int? id)
        {
            var model = context.hotels.Where(x => x.id == id).FirstOrDefault();
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetDetialHotels()
        {

            var model = context.hotels.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndGetDichVuHotel(int? id)
        {

            var model = context.DichVu_HT_HS.Where(x => x.theLoai == "hotel" && x.idHTHS == id).ToList();
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndAddItemHotel(int id)
        {
            var hotel = context.hotels.Find(id);
            string json = JsonConvert.SerializeObject(hotel, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndSearchEngine_Price1(int? page, string txtSearch, string locationSelect)
        {

            var model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price < 300000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndSearchEngine_Price2(int? page, string txtSearch, string locationSelect)
        {
            var model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price >= 300000 && h.sell_price < 500000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndSearchEngine_Price3(int? page, string txtSearch, string locationSelect)
        {
            var model = context.hotels.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelect && (h.sell_price >= 500000 && h.sell_price < 1000000) && h.hotel_name.Contains(txtSearch))).ToPagedList(page ?? 1, 9);
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndOpitionList()
        {
            var optionList = context.locations.Where(o => o.id != null).ToList();
            string json = JsonConvert.SerializeObject(optionList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndMinPrice()
        {
            var minPrice = context.hotels.Min(h => h.sell_price);
            string json = JsonConvert.SerializeObject(minPrice, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndMaxPrice()
        {
            var maxPrice = context.hotels.Max(h => h.sell_price);
            string json = JsonConvert.SerializeObject(maxPrice, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        //------------------------THANG----------------------------------
        //------------------------HIEU----------------------------------
        //homestay
        [WebMethod]
        public string FEFindHomestayByPriceMedium(int? page, string txtSearch, string locationSelected)
        {
            var result = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelected && (h.sell_price >= 300000 && h.sell_price < 500000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page?? 1 , 9);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FEFindHomestayByPriceHigh(int? page, string txtSearch, string locationSelected)
        {
            var result = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name.ToLower() == locationSelected && (h.sell_price >= 500000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page?? 1 , 9);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEFindHomestayByPriceLow(int? page, string txtSearch, string locationSelected)
        {
            var result = context.homestays.OrderByDescending(h => h.id).Where(h => (h.location.location_name == locationSelected && (h.sell_price < 300000) && h.homestay_name.Contains(txtSearch))).ToPagedList(page?? 1, 9);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEGetListHomestays(int? page)
        {
            //var model = context.homestays.Where(x => x.id != 0).ToList();
            var model = context.homestays.OrderByDescending(h => h.id).ToPagedList(page ?? 1, 9);
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEGetDetailHomestay(int? id)
        {
            var model = context.homestays.Where(x => x.id == id).FirstOrDefault();
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndGetDichVuHomestay(int? id)
        {

            var model = context.DichVu_HT_HS.Where(x => x.theLoai == "homestay" && x.idHTHS == id).ToList();
            string json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEGetDetailHomestay0()
        {
            var list = context.homestays.Where(x => x.id != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }


        [WebMethod]
        public string FEAddItemHomestay(int id)
        {
            var result = context.homestays.Find(id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEAddItem1(int id)
        {
            var result = context.homestays.Find(id);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var homestay = JsonConvert.DeserializeObject<homestay_booking>(json);
            context.homestay_booking.Add(homestay);
            context.SaveChanges();
            return json;
        }

        [WebMethod]
        public string FEOpitionList()
        {
            var optionList = context.locations.Where(o => o.id != null).ToList();
            string json = JsonConvert.SerializeObject(optionList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEMinPrice()
        {
            var minPrice = context.homestays.Min(h => h.sell_price);
            string json = JsonConvert.SerializeObject(minPrice, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FEMaxPrice()
        {
            var maxPrice = context.homestays.Max(h => h.sell_price);
            string json = JsonConvert.SerializeObject(maxPrice, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string GetListDichVu_HTHS_BE()
        {
            var list = context.DichVu_HT_HS.Where(x => x.idHTHS != 0).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndGetListDV()
        {
            var list = context.DichVus.Where(x => x.idDichVu != null);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public string FrontEndGetListTenDV()
        {
            var list = context.DichVus.Where(x => x.tenDichVu != null);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public string FrontEndGetTheLoai()
        {
            var list = context.DichVu_HT_HS.Where(x => x.theLoai != null);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
        [WebMethod]
        public void AddDichVu_BE(string json)
        {
            var dvhths = JsonConvert.DeserializeObject<DichVu_HT_HS>(json);
            context.DichVu_HT_HS.Add(dvhths);
            context.SaveChanges();
        }

        [WebMethod]
        public void NewDV_BE(string json)
        {
            var dv = JsonConvert.DeserializeObject<DichVu>(json);
            context.DichVus.Add(dv);
            context.SaveChanges();
        }
        [WebMethod]
        public string GetDichVu_HTHS_BE()
        {
            var list = context.DichVu_HT_HS.Where(x => x.idDichVu != null).ToList();
            string json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [WebMethod]
        public void ThemMoiDichVu_BE(string json)
        {
            DichVu dv = JsonConvert.DeserializeObject<DichVu>(json);
            context.DichVus.Add(dv);
            context.SaveChanges();
        }
        [WebMethod]
        public void ThemMoiDichVu2_BE(string id, string ten)
        {
            DichVu Dv = new DichVu(id, ten);
            context.DichVus.Add(Dv);
            //DichVu dv = JsonConvert.DeserializeObject<DichVu>(json);
            //context.DichVus.Add(dv);
            context.SaveChanges();
        }
        

        [WebMethod]
        public void DeleteDichVu_BE(int id, string theLoai, string idDichVu)
        {
            //var listBooking = context.DichVus.Where(x => x.idDichVu.Length == id).ToList();
            var listDichVu = context.DichVu_HT_HS.Where(x => x.idHTHS == id && x.theLoai == theLoai && x.idDichVu == idDichVu).SingleOrDefault();
            context.DichVu_HT_HS.Remove(listDichVu);
            /*foreach (var item in listBooking)
            {
                context.DichVus.Remove(item);
            }*/
            context.SaveChanges();
            //context.DichVus.Remove(context.DichVus.Find(id));
            //context.SaveChanges();

        }
        [WebMethod]
        public string GetDichVuByID(string id)
        {
            var dv = context.DichVus.Where(x => x.idDichVu == id).SingleOrDefault();
            string json = JsonConvert.SerializeObject(dv, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;

        }
        //------------------------HIEU----------------------------------
    }
}
