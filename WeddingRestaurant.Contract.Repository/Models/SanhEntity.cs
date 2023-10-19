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
        [Key]
        public string MaSanh { get; set; }
        public string TenSanh { get; set; }
        public int SucChucToiThieu { get; set;}
        public int SucChucToiDa { get; set; }
        public virtual ICollection<LichSanhTiecEntity>? LichSanhTiecs { get; set; }
    }
}
