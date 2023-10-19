using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.MonAnTrongMenu
{
    public class MonAnTrongMenuModel
    {
        public string MaMenu { get; set; }
        public string MaMonAn { get; set; }
        public int SoLuongMon { get; set; }
        public double DonGia { get; set; }
    }
}
