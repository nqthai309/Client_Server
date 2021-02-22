using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_N8_MVC.Models
{
    [Serializable]
    public class CartItem {
        private Product product;
        private int quantity;
        private string selectDichVu;
        private int thanhTienDichVu;

        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public CartItem(Product product, int quantity, string selectDichVu, int thanhTienDichVu)
        {
            this.product = product;
            this.quantity = quantity;
            this.selectDichVu = selectDichVu;
            this.thanhTienDichVu = thanhTienDichVu;
        }

        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string SelectDichVu { get => selectDichVu; set => selectDichVu = value; }
        public int ThanhTienDichVu { get => thanhTienDichVu; set => thanhTienDichVu = value; }
    }

    public class Cart
    {
        static List<CartItem> lineCollections = new List<CartItem>();

        public void AddItemHotel(hotel hotel,string checkin, string checkout, int quantity, string selectDichVu, int thanhTienDichVu)
        {
            CartItem line = lineCollections.Where(p => p.Product.Id == hotel.id.ToString() && p.Product.Status_checking == "hotel" && p.Product.Checkin == checkin && p.SelectDichVu == selectDichVu).FirstOrDefault();
            if(line == null)
            {
                var prod = new Product(hotel.id.ToString(), hotel.hotel_name, hotel.sell_price.ToString(), hotel.price.ToString(), "hotel",checkin, checkout);

                lineCollections.Add(new CartItem(prod, quantity, selectDichVu, thanhTienDichVu));
            }
            else
            {
                line.Quantity += quantity;
                line.SelectDichVu = selectDichVu;
                line.ThanhTienDichVu = thanhTienDichVu;
            }
            
        }
        public void AddItemHomestay(homestay homeStay,string checkin, string checkout, int quantity, string selectDichVu, int thanhTienDichVu)
        {
            CartItem line = lineCollections.Where(p => p.Product.Id == homeStay.id.ToString() && p.Product.Status_checking == "homestay" && p.Product.Checkin == checkin && p.SelectDichVu == selectDichVu).FirstOrDefault();
            if (line == null)
            {
                var prod = new Product(homeStay.id.ToString(),homeStay.homestay_name, homeStay.sell_price.ToString(), homeStay.price.ToString(), "homestay",checkin,checkout);
                lineCollections.Add(new CartItem(prod, quantity, selectDichVu, thanhTienDichVu));
            }
            else
            {
                line.Quantity += quantity;
                line.SelectDichVu = selectDichVu;
                line.ThanhTienDichVu = thanhTienDichVu;
            }
        }
        public void RemoveLineProduct(Product product)
        {
            if(product.Status_checking == "hotel")
            {
                lineCollections.RemoveAll(l => l.Product.Id == product.Id && l.Product.Status_checking == "hotel" && l.Product.Checkin == product.Checkin);
            }
            else if(product.Status_checking == "homestay")
            {
                lineCollections.RemoveAll(l => l.Product.Id == product.Id && l.Product.Status_checking == "homestay" && l.Product.Checkin == product.Checkin);
            }
            
        }
        public void Clear()
        {
            lineCollections.Clear();
        }
        
        public IEnumerable<CartItem> lines { get { return lineCollections; } }
    }
}