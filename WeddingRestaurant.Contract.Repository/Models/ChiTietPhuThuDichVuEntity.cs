using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietPhuThuDichVu")]
    public class ChiTietPhuThuDichVuEntity : Entity
    {
        // Khóa ngoại bảng PhuThu
        public string MaPhuThu { get; set; }
        public virtual PhuThuEntity PhuThus { get; set; }

        // Khóa ngoại bảng DichVuTinhPhi
        public string MaDichVuTinhPhi { get; set; }
        public virtual DichVuTinhPhiEntity DichVuTinhPhis { get; set; }

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}
