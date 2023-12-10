using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingRestaurant.Core.Constants.WebApiEndpoint;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DichVuTinhPhi")]
    public class DichVuTinhPhiEntity : Entity
    {
        public string MaDichVuTinhPhi { get; set; }
        public string TenDichVu { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public int DieuKienBanToiThieu { get; set; }
        public int DieuKienBanToiDa { get; set; }
        public double GiaTronGoi { get; set; }
        public double GiaGiam30 { get; set; }
        public double GiaLe { get; set; }

        // Khóa ngoại bảng DichVu
        public string MaDichVu { get; set; }
        public virtual DichVuEntity DichVus { get; set; }

        public virtual ICollection<ChiTietDichVuTinhPhiEntity>? ChiTietDichVuTinhPhis { get; set; }
        public virtual ICollection<ChiTietPhuThuDichVuEntity>? ChiTietPhuThuDichVus { get; set; }

    }
}
