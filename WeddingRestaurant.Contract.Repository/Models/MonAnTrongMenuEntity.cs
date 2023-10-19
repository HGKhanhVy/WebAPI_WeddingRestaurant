using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("MonAnTrongMenu")]
    public class MonAnTrongMenuEntity : Entity
    {
        [ForeignKey("Menu")]
        public string MaMenu { get; set; }
        public virtual MenuEntity? Menus { get; set; }

        [ForeignKey("MonAn")]
        public string MaMonAn { get; set; }
        public virtual MonAnEntity? MonAns { get; set; }

        public int SoLuongMon { get; set; }
        public double DonGia { get; set; }
    }
}
