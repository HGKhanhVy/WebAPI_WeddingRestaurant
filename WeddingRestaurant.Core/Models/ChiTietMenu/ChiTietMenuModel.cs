using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.ChiTietMenu
{
    public class ChiTietMenuModel
    {
        public string MaTiec { get; set; }
        public string MaMenu { get; set; }
        public int SoLuongMenuCuaTiec { get; set; }
        public double TongTien { get; set; }
    }
}
