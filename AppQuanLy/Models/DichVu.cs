namespace AppQuanLy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            DichVu_HT_HS = new HashSet<DichVu_HT_HS>();
        }

        [Key]
        [StringLength(250)]
        public string idDichVu { get; set; }

        [StringLength(250)]
        public string tenDichVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichVu_HT_HS> DichVu_HT_HS { get; set; }

        public DichVu(string idDichVu, string tenDichVu)
        {
            this.idDichVu = idDichVu;
            this.tenDichVu = tenDichVu;
        }
    }
}
