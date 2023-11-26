using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DichVuTinhPhi")]
    public class DichVuTinhPhiEntity : Entity
    {
        public string MaDichVuTinhPhi { get; set; }
        public string TenDichVu { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public double DonGiaDichVu { get; set; }

        // Khóa ngoại bảng DichVu
        public string MaDichVu { get; set; }
        public virtual DichVuEntity DichVus { get; set; }

        public virtual ICollection<ChiTietDichVuTinhPhiEntity>? ChiTietDichVuTinhPhis { get; set; }
        public virtual ICollection<ChiTietPhuThuDichVuEntity>? ChiTietPhuThuDichVus { get; set; }
    }
}
