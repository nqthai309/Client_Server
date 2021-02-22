namespace AppQuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class homestay_booking
    {
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
    }
}
