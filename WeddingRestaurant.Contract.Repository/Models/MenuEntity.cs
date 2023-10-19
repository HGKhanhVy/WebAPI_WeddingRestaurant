using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("Menu")]
    public class MenuEntity : Entity
    {
        [Key]
        public string MaMenu { get; set; }
        public double DonGiaMenu { get; set; }
        public virtual ICollection<MonAnTrongMenuEntity>? MonAnTrongMenus { get; set; }
        public virtual ICollection<ChiTietMenuEntity>? ChiTietMenus { get; set; }
    }
}
