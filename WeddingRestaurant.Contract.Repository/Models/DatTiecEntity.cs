using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Repository.Models
{
    [Table("DatTiec")]
    public class DatTiecEntity : Entity
    {
        [Key]
        public string MaTiec { get; set; }
        public string TenTiec { get; set; }
        public int SoBan { get; set; }
        public double PhiDichVu { get; set; }
        public DateTimeOffset NgayDatTiec { get; set;}
        public DateTimeOffset NgayToChuc { get; set; }
        public string TrangThai { get; set; }

        [ForeignKey("KhachHang")]
        public string MaKhachHang { get; set; }
        public virtual KhachHangEntity? KhachHangs { get; set; }

        public virtual ICollection<LichSanhTiecEntity>? LichSanhTiecs { get; set; }
        public virtual ICollection<SuDungKhuyenMaiEntity>? SuDungKhuyenMais { get; set; }
        public virtual ICollection<ChiTietDichVuEntity>? ChiTietDichVus { get; set; }
        public virtual ICollection<ChiTietMenuEntity>? ChiTietMenus { get; set; }
        public virtual ICollection<ChiTietNuocUongEntity>? ChiTietNuocUongs { get; set; }
    }
}
