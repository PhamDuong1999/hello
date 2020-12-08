namespace ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string Avatar { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        [StringLength(50)]
        public string KieuMay { get; set; }

        public int? KichThuoc { get; set; }

        [StringLength(50)]
        public string ChatLieuVo { get; set; }

        [StringLength(50)]
        public string ChatLieuDay { get; set; }

        [StringLength(50)]
        public string ChatLieuKinh { get; set; }

        public int? MaNCC { get; set; }

        public int? MaDM { get; set; }

        public int? TrangThai { get; set; }
    }
}
