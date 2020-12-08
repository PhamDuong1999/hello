namespace ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenDM { get; set; }

        public int? TrangThai { get; set; }
    }
}
