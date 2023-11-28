using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("Sanh")]
    public class SanhEntity : Entity
    {
        public string MaSanh { get; set; }
        public string TenSanh { get; set; }
        public string HinhAnh { get; set; }
        public int SucChuaToiThieu { get; set;}
        public int SucChuaToiDa { get; set; }

        public virtual ICollection<LichSanhTiecEntity>? LichSanhTiecs { get; set; }
    }
}
