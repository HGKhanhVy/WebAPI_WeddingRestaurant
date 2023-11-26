using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{ 
    [Table("LoaiNuoc")]
    public class LoaiNuocEntity : Entity
    {
        public string MaLoaiNuoc { get; set; }
        public string TenLoaiNuoc { get; set; }

        public virtual ICollection<NuocEntity>? Nuocs { get; set; }
    }
}
