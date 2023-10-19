using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("ChiTietMenu")]
    public class ChiTietMenuEntity : Entity
    {
        [ForeignKey("DatTiec")]
        public string MaTiec { get; set; }
        public virtual DatTiecEntity? DatTiecs { get; set; }

        [ForeignKey("Menu")]
        public string MaMenu { get; set; }
        public virtual MenuEntity? Menus { get; set; }

        public int SoLuongMenuBan { get; set; }
        public double TongTien { get; set; }
    }
}
