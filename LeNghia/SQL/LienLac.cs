namespace LeNghia.SQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienLac")]
    public partial class LienLac
    {
        [Key]
        [StringLength(50)]
        public string MaLienLac { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNhom { get; set; }

        [Required]
        [StringLength(50)]
        public string TenGoi { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int SoDienThoai { get; set; }
    }
}
