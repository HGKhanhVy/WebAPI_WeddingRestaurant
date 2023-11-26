using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.NhanVien
{
    public class NhanVienModel
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string Gmail { get; set; }
        public string NgayVaoLam { get; set; }
        public string? NgayNghiViec { get; set; }
    }
}
