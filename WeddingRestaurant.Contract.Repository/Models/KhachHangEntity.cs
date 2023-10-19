using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("KhachHang")]
    public class KhachHangEntity : Entity
    {
        [Key]
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string Gmail { get; set; }
        public virtual ICollection<DatTiecEntity>? DatTiecs { get; set; }
    }
}
