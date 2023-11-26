using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.Sanh
{
    public class SanhModel
    {
        public string MaSanh { get; set; }
        public string TenSanh { get; set; }
        public int SucChuaToiThieu { get; set; }
        public int SucChuaToiDa { get; set; }
        public string TrangThai { get; set; }
    }
}
