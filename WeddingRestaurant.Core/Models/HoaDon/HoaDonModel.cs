using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Core.Models.HoaDon
{
    public class HoaDonModel
    {
        public string MaHoaDon { get; set; }
        public string NgayLap { get; set; }
        public string MaTiec { get; set; }
    }
}
