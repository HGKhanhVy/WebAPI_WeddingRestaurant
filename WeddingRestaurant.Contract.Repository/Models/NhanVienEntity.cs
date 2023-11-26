using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("NhanVien")]
    public class NhanVienEntity : Entity
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string Gmail { get; set; }
        public string NgayVaoLam { get; set; }
        public string? NgayNghiViec { get; set; }

        public virtual ICollection<NhanVienTrongTiecEntity>? NhanVienTrongTiecs { get; set; }
    }
}
