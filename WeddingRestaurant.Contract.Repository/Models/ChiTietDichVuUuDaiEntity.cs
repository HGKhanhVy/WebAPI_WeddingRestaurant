using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietDichVuUuDai")]
    public class ChiTietDichVuUuDaiEntity : Entity
    {
        // Khóa ngoại bảng DatTiec
        public string MaTiec { get; set; }
        public virtual DatTiecEntity DatTiecs { get; set; }

        // Khóa ngoại bảng DichVuUuDai
        public string MaDichVuUuDai { get; set; }
        public virtual DichVuUuDaiEntity DichVuUuDais { get; set; }
    }
}
