using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.ChiTietPhuThuNuoc
{
    public class ChiTietPhuThuNuocModel
    {
        public string MaPhuThu { get; set; }
        public string MaNuoc { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
    }
}
