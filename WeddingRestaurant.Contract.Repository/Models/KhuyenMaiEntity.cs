using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("KhuyenMai")]
    public class KhuyenMaiEntity : Entity
    {
        [Key]
        public string MaKM { get; set; }
        public string DieuKien { get; set; }
        public double GiaTri { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<SuDungKhuyenMaiEntity>? SuDungKhuyenMais { get; set; }
    }
}
