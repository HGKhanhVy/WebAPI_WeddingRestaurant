using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietDichVuTinhPhi")]
    public class ChiTietDichVuTinhPhiEntity : Entity
    {
        // Khóa ngoại bảng DatTiec
        public string MaTiec { get; set; }
        public virtual DatTiecEntity DatTiecs { get; set; }
        
        // Khóa ngoại bảng DichVuTinhPhi
        public string MaDichVuTinhPhi { get; set; }
        public virtual DichVuTinhPhiEntity DichVuTinhPhis { get; set; }
    }
}
