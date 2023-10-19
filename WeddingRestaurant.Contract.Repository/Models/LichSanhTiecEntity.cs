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
        [ForeignKey("DatTiec")]
        public string MaTiec { get; set; }
        public virtual DatTiecEntity? DatTiecs { get; set; }

        [ForeignKey("Sanh")]
        public string MaSanh { get; set; }
        public virtual SanhEntity? Sanhs { get; set; }

        public DateTimeOffset NgayToChuc { get; set; }
        public string Ca { get; set; }
        public string TrangThai { get; set; }

    }
}
