using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [ReadOnly(true)]
        public string MaTiec { get; private set; }
        public string LoaiHinhTiec { get; set; }
        public DateTime NgayDatTiec { get; set; }
        public DateTime NgayToChuc { get; set; }
        public DateTime ThoiGianToChuc { get; set; }
        public int SoLuongBanChinhThuc { get; set; }
        public int SoLuongBanTang { get; set; }
        public int SoLuongBanChay { get; set; }
        public int SoLuongBanDuPhong { get; set; }
        public int TongBanSetup { get; set; }
        public string LoaiBan { get; set; }
        public double PhiDichVu { get; set; }
        public double TongTienDuKien { get; set; }
        public double TongTienGiam { get; set; }
        public double TongTienPhaiTra { get; set; }
        public double TienCocLan1 { get; set; }
        public double TienCocLan2 { get; set; }
        public string GhiChu { get; set; }

        // Khóa ngoại bảng KhachHang
        public string MaKhachHang { get; set; }
        public virtual KhachHangEntity KhachHangs { get; set; }
        
        // Khóa ngoại bảng HoaDon
        public string MaHoaDon { get; set; }
        public virtual HoaDonEntity HoaDons { get; set; }

        public virtual ICollection<LichSanhTiecEntity>? LichSanhTiecs { get; set; }
        public virtual ICollection<ChiTietDichVuUuDaiEntity>? ChiTietDichVuUuDais { get; set; }
        public virtual ICollection<ChiTietDichVuTinhPhiEntity>? ChiTietDichVuTinhPhis { get; set; }
        public virtual ICollection<ChiTietMenuEntity>? ChiTietMenus { get; set; }
        public virtual ICollection<ChiTietNuocUongEntity>? ChiTietNuocUongs { get; set; }
        public virtual ICollection<NhanVienTrongTiecEntity>? NhanVienTrongTiecs { get; set; }

        public DatTiecEntity()
        {
            MaTiec = "TC" + Guid.NewGuid().ToString("N");
        }
    }
}
