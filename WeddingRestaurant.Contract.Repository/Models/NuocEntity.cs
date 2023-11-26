using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("Nuoc")]
    public class NuocEntity : Entity
    {
        public string MaNuoc{ get; set; }
        public string TenNuoc { get; set; }
        public string DVT { get; set; }
        public double DonGia { get; set; }

        // Khóa ngoại bảng LoaiNuoc
        public string MaLoaiNuoc { get; set; }
        public virtual LoaiNuocEntity LoaiNuocs { get; set; }

        public virtual ICollection<ChiTietNuocUongEntity>? ChiTietNuocUongs { get; set; }
        public virtual ICollection<ChiTietPhuThuNuocEntity>? ChiTietPhuThuNuocs { get; set; }
    }
}
