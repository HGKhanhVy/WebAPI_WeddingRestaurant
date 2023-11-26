using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietPhuThuMonAn")]
    public class ChiTietPhuThuMonAnEntity : Entity
    {
        // Khóa ngoại bảng PhuThu
        public string MaPhuThu { get; set; }
        public virtual PhuThuEntity PhuThus { get; set; }

        // Khóa ngoại bảng MonAn
        public string MaMonAn { get; set; }
        public virtual MonAnEntity MonAns { get; set; }

        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}
