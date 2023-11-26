using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("PhuThu")]
    public class PhuThuEntity : Entity
    {
        public string MaPhuThu { get; set; }
        public string LoaiPhuThu { get; set; }
        public string MoTaPhuThu { get; set; }
        public double TongTien { get; set; }

        // Khóa ngoại bảng HoaDon
        public string MaHoaDon { get; set; }
        public virtual HoaDonEntity HoaDons { get; set; }

        public virtual ICollection<ChiTietPhuThuMonAnEntity>? ChiTietPhuThuMonAns { get; set; }
        public virtual ICollection<ChiTietPhuThuNuocEntity>? ChiTietPhuThuNuocs { get; set; }
        public virtual ICollection<ChiTietPhuThuDichVuEntity>? ChiTietPhuThuDichVus { get; set; }
    }
}
