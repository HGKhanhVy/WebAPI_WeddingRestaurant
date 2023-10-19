using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DichVu")]
    public class DichVuEntity : Entity
    {
        [Key]
        public string MaDichVu { get; set; }    
        public string TenDichVu { get; set; }
        public double DonGiaDichVu { get; set; }
        public virtual ICollection<ChiTietDichVuEntity>? ChiTietDichVus { get; set; }
    }
}
