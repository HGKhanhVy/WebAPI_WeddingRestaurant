using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.DatTiec
{
    public class DatTiecModel
    {
        public string MaTiec { get; set; }
        public string TenTiec { get; set; }
        public int SoBan { get; set; }
        public double PhiDichVu { get; set; }
        public DateTimeOffset NgayDatTiec { get; set; }
        public DateTimeOffset NgayToChuc { get; set; }
        public string TrangThai { get; set; }
        public string MaKhachHang { get; set; }
    }
}
