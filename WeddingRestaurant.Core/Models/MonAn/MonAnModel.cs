using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.MonAn
{
    public class MonAnModel
    {
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public double DonGia { get; set; }
        public string DVT { get; set; }
        public string MaLoaiMon { get; set; }
    }
}
