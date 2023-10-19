using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.ChiTietDichVu
{
    public class ChiTietDichVuModel
    {
        public string MaTiec { get; set; }
        public string MaDichVu { get; set; }
        public double TongTien { get; set; }
    }
}
