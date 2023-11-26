using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietPhuThuNuoc")]
    public class ChiTietPhuThuNuocEntity : Entity
    {
        // Khóa ngoại bảng PhuThu
        public string MaPhuThu { get; set; }
        public virtual PhuThuEntity PhuThus { get; set; }

        // Khóa ngoại bảng Nuoc
        public string MaNuoc { get; set; }
        public virtual NuocEntity Nuocs { get; set; }

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
