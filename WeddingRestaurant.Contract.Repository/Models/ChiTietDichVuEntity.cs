using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietDichVu")]
    public class ChiTietDichVuEntity : Entity
    {
        [ForeignKey("DatTiec")]
        public string MaTiec { get; set; }
        public virtual DatTiecEntity? DatTiecs { get; set; }

        [ForeignKey("DichVu")]
        public string MaDichVu { get; set; }
        public virtual DichVuEntity? DichVus { get; set; }

        public double TongTien { get; set; }
    }
}
