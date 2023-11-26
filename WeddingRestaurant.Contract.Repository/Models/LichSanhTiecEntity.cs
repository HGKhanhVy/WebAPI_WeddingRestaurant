using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("LichSanhTiec")]
    public class LichSanhTiecEntity : Entity
    {
        // Khóa ngoại Đặt tiệc
        public string MaTiec { get; set; }
        public virtual DatTiecEntity DatTiecs { get; set; }

        // Khóa ngoại Sảnh
        public string MaSanh { get; set; }
        public virtual SanhEntity Sanhs { get; set; }

        public DateTime NgayDienRa { get; set; }
        public string Ca { get; set; } 
        public double TienPhuThu { get; set; }

    }
}
