using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DanhGia")]
    public class DanhGiaEntity : Entity
    {
        public string MaDanhGia { get; set; }
        public string NoiDungDanhGia { get; set; }

        // Khóa ngoại bảng KhachHang
        public string MaKhachHang { get; set; }
        public virtual KhachHangEntity KhachHangs { get; set; }
    }
}
