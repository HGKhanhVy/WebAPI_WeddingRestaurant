using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietNuocUong")]
    public class ChiTietNuocUongEntity : Entity
    {
        // Khóa ngoại bảng DatTiec
        public string MaTiec { get; set; }
        public virtual DatTiecEntity DatTiecs { get; set; }

        // Khóa ngoại bảng Nuoc
        public string MaNuoc { get; set; }
        public virtual NuocEntity Nuocs { get; set; }

        public int SoLuong { get; set; }
        public double TongTien { get; set; }
    }
}
