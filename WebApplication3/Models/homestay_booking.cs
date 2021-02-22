namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class homestay_booking
    {
        public homestay_booking(int id, string full_name, string email, string phone, string address, int? homestay_id, DateTime? from_date, DateTime? to_date, int? total_price, string selectDichVu, int? thanhTienDichVu, string v)
        {
            this.id = id;
            this.homestay_id = homestay_id;
            this.from_date = from_date;
            this.to_date = to_date;
            this.total_price = total_price;
            this.selectDichVu = selectDichVu;
            this.thanhTienDichVu = thanhTienDichVu;
        }

        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(100)]
        public string customer_email { get; set; }

        [StringLength(100)]
        public string customer_phone { get; set; }

        [StringLength(100)]
        public string customer_address { get; set; }

        public int? homestay_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? from_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? to_date { get; set; }

        public int? total_price { get; set; }

        [StringLength(250)]
        public string selectDichVu { get; set; }

        public int? thanhTienDichVu { get; set; }

        [StringLength(250)]
        public string status_check { get; set; }

        public virtual homestay homestay { get; set; }

        public homestay_booking()
        {
        }
    }
}
