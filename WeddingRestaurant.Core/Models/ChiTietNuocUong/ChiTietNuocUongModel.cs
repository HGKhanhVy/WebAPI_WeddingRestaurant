using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.ChiTietNuocUong
{
    public class ChiTietNuocUongModel
    {
        public string MaTiec { get; set; }
        public string MaNuoc { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }
    }
}
