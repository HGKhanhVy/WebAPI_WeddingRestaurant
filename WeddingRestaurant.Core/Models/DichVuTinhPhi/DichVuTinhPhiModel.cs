using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.DichVuTinhPhi
{
    public class DichVuTinhPhiModel
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
        public string MaDichVu { get; set; }
    }
}
