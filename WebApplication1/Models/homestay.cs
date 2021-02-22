namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("homestay")]
    public partial class homestay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public homestay()
        {
            homestay_booking = new HashSet<homestay_booking>();
        }

        public int id { get; set; }

        public int? location_id { get; set; }

        [Required]
        [StringLength(100)]
        public string homestay_name { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<homestay_booking> homestay_booking { get; set; }

        public virtual location location { get; set; }
    }
}
