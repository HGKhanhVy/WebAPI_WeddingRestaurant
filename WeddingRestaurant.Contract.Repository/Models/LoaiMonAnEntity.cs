using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("LoaiMonAn")]
    public class LoaiMonAnEntity : Entity
    {
        [Key]
        public string MaLoaiMon { get; set; }
        public string TenLoaiMon { get; set; }

        public virtual ICollection<MonAnEntity>? MonAns { get; set; }
    }
}
