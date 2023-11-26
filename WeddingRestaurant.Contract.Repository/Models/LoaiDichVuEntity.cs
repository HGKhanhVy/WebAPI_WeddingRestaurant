using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("LoaiDichVu")]
    public class LoaiDichVuEntity : Entity
    {
        public string MaLoaiDichVu { get; set; }
        public string TenLoaiDichVu { get; set; }

        public virtual ICollection<DichVuEntity>? DichVus { get; set; }
    }
}
