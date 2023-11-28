using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("MonAn")]
    public class MonAnEntity : Entity
    {
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public double DonGia { get; set; }
        public string HinhAnh { get; set; }
        public string DVT { get; set; }

        // Khóa ngoại LoaiMonAn
        public string MaLoaiMonAn { get; set; }
        public virtual LoaiMonAnEntity LoaiMonAns { get; set; }

        public virtual ICollection<MonAnTrongMenuEntity>? MonAnTrongMenus { get; set; }
        public virtual ICollection<ChiTietPhuThuMonAnEntity>? ChiTietPhuThuMonAns { get; set; }
    }
}
