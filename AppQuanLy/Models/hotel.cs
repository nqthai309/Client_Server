namespace AppQuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hotel")]
    public partial class hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hotel()
        {
            hotel_booking = new HashSet<hotel_booking>();
        }

        public int id { get; set; }

        public int? location_id { get; set; }

        [Required]
        [StringLength(100)]
        public string hotel_name { get; set; }

        [StringLength(100)]
        public string image_url { get; set; }

        [StringLength(100)]
        public string detail_header_image_url { get; set; }

        [StringLength(100)]
        public string more_imformation_image_url { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "text")]
        public string more_imformation { get; set; }

        public int? price { get; set; }

        public int? sell_price { get; set; }

        public virtual location location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hotel_booking> hotel_booking { get; set; }

        public hotel(int? location_id, string hotel_name, string image_url, string detail_header_image_url, string more_imformation_image_url, string description, string more_imformation, int? price, int? sell_price)
        {
            this.location_id = location_id;
            this.hotel_name = hotel_name;
            this.image_url = image_url;
            this.detail_header_image_url = detail_header_image_url;
            this.more_imformation_image_url = more_imformation_image_url;
            this.description = description;
            this.more_imformation = more_imformation;
            this.price = price;
            this.sell_price = sell_price;
        }
    }
}
