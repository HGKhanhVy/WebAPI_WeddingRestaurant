using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("HoaDon")]
    public class HoaDonEntity : Entity
    {
        public string MaHoaDon { get; set; }
        public string NgayLap { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(18,2)")]
        public double? TongTienPhuThu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(18,2)")]
        public double? TongTienThanhToan { get; set; }

        public string MaTiec { get; set; }
        public DatTiecEntity DatTiecs { get; set; }
        public virtual ICollection<PhuThuEntity>? PhuThus { get; set; }
    }
}
