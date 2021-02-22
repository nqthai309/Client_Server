namespace CNW_N8_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DichVu_HT_HS
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idHTHS { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string theLoai { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string idDichVu { get; set; }

        [StringLength(250)]
        public string tenDichVu { get; set; }

        public int? donGiaDichVu { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
