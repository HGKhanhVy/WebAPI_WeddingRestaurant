using Microsoft.EntityFrameworkCore;
using WeddingRestaurant.Contract.Repository.Models;

namespace WeddingRestaurant.Repository.Infrastructure
{
    public sealed partial class AppDbContext
    {
        public DbSet<ChiTietDichVuEntity> ChiTietDichVu { get; set; }
        public DbSet<ChiTietMenuEntity> ChiTietMenu { get; set; }
        public DbSet<ChiTietNuocUongEntity> ChiTietNuocUong { get; set; }
        public DbSet<DatTiecEntity> DatTiec { get; set; }
        public DbSet<DichVuEntity> DichVu { get; set; }
        public DbSet<KhachHangEntity> KhachHang { get; set; }
        public DbSet<KhuyenMaiEntity> KhuyenMai { get; set; }
        public DbSet<LichSanhTiecEntity> LichSanhTiec { get; set; }
        public DbSet<LoaiMonAnEntity> LoaiMonAn { get; set; }
        public DbSet<LoaiNuocEntity> LoaiNuoc { get; set; }
        public DbSet<MenuEntity> Menu { get; set; }
        public DbSet<MonAnEntity> MonAn { get; set; }
        public DbSet<MonAnTrongMenuEntity> MonAnTrongMenu { get; set; }
        public DbSet<NuocEntity> Nuoc { get; set; }
        public DbSet<SanhEntity> Sanh { get; set; }
        public DbSet<SuDungKhuyenMaiEntity> SuDungKhuyenMai { get; set; }
        public DbSet<NguoiDungEntity> NguoiDung { get; set; }
        public DbSet<TokenEntity> Token { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<AccessTokenEntity> AccessToken { get; set; }
    }
}
