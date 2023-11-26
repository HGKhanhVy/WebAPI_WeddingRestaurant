using Microsoft.EntityFrameworkCore;
using WeddingRestaurant.Contract.Repository.Models;

namespace WeddingRestaurant.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<ChiTietDichVuTinhPhiEntity> ChiTietDichVuTinhPhi { get; set; }
        public DbSet<ChiTietDichVuUuDaiEntity> ChiTietDichVuUuDai { get; set; }
        public DbSet<ChiTietMenuEntity> ChiTietMenu { get; set; }
        public DbSet<ChiTietNuocUongEntity> ChiTietNuocUong { get; set; }
        public DbSet<ChiTietPhuThuDichVuEntity> ChiTietPhuThuDichVu { get; set; }
        public DbSet<ChiTietPhuThuMonAnEntity> ChiTietPhuThuMonAn { get; set; }
        public DbSet<ChiTietPhuThuNuocEntity> ChiTietPhuThuNuoc { get; set; }
        public DbSet<DatTiecEntity> DatTiec { get; set; }
        public DbSet<DichVuEntity> DichVu { get; set; }
        public DbSet<DichVuTinhPhiEntity> DichVuTinhPhi { get; set; }
        public DbSet<DichVuUuDaiEntity> DichVuUuDai { get; set; }
        public DbSet<HoaDonEntity> HoaDon { get; set; }
        public DbSet<KhachHangEntity> KhachHang { get; set; }
        public DbSet<LichSanhTiecEntity> LichSanhTiec { get; set; }
        public DbSet<LoaiDichVuEntity> LoaiDichVu { get; set; }
        public DbSet<LoaiMonAnEntity> LoaiMonAn { get; set; }
        public DbSet<LoaiNuocEntity> LoaiNuoc { get; set; }
        public DbSet<MenuEntity> Menu { get; set; }
        public DbSet<MonAnEntity> MonAn { get; set; }
        public DbSet<MonAnTrongMenuEntity> MonAnTrongMenu { get; set; }
        public DbSet<NuocEntity> Nuoc { get; set; }
        public DbSet<NhanVienEntity> NhanVien { get; set; }
        public DbSet<NhanVienTrongTiecEntity> NhanVienTrongTiec { get; set; }
        public DbSet<PhuThuEntity> PhuThu { get; set; }
        public DbSet<SanhEntity> Sanh { get; set; }
        public DbSet<NguoiDungEntity> NguoiDung { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<AccessTokenEntity> AccessToken { get; set; }
    }
}
