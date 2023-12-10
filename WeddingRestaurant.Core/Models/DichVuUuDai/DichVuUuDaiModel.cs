using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.DichVuUuDai
{
    public class DichVuUuDaiModel
    {
        public string MaDichVuUuDai { get; set; }
        public string TenDichVu { get; set; }
        public int DieuKienBanToiThieu { get; set; }
        public int DieuKienBanToiDa { get; set; }
        public string? MoTa { get; set; }
        public string? HinhAnh { get; set; }
        public string MaDichVu { get; set; }
    }
}
