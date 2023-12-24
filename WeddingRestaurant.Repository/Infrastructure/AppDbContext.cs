using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Repository.Base;
using System.Reflection;
using WeddingRestaurant.Core.Utils;
using WeddingRestaurant.Core.Configs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WeddingRestaurant.Contract.Repository.Models;

namespace WeddingRestaurant.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IDbContext))]
    public sealed partial class AppDbContext : BaseDbContext
    {
        public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });

        public readonly int CommandTimeoutInSecond = 20 * 60;

        public AppDbContext() : base()
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*  var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.Development.json")
                      .Build();
                  var connectionString = configuration.GetConnectionString("DefaultConnection");*/
                // data source = KHANHVY\SQLEXPRESS; initial catalog = DB_WeddingRestaurant; user id = sa; password =<< YourPassword >>
                var connectionString = SystemHelper.AppDb;
                connectionString = "Data Source=(local)\\SQLEXPRESS;initial Catalog=DB_WeddingRestaurant;user id=sa;password=123;Trusted_Connection=True;Trust Server Certificate=True; Integrated Security=false";

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(
                        typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);

                    sqlServerOptionsAction.MigrationsHistoryTable("Migration");
                });
                optionsBuilder.UseLoggerFactory(LoggerFactory);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chi Tiet Dich Vu Tinh Phi
            modelBuilder.Entity<ChiTietDichVuTinhPhiEntity>()
                .HasKey(e => new { e.MaTiec, e.MaDichVuTinhPhi });
            modelBuilder.Entity<ChiTietDichVuTinhPhiEntity>()
                .HasOne(c => c.DatTiecs)
                .WithMany(t => t.ChiTietDichVuTinhPhis)
                .HasForeignKey(c => c.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietDichVuTinhPhiEntity>()
                .HasOne(c => c.DichVuTinhPhis)
                .WithMany(d => d.ChiTietDichVuTinhPhis)
                .HasForeignKey(c => c.MaDichVuTinhPhi)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Dich Vu Uu Dai
            modelBuilder.Entity<ChiTietDichVuUuDaiEntity>()
                .HasKey(e => new { e.MaTiec, e.MaDichVuUuDai });
            modelBuilder.Entity<ChiTietDichVuUuDaiEntity>()
                .HasOne(c => c.DatTiecs)
                .WithMany(t => t.ChiTietDichVuUuDais)
                .HasForeignKey(c => c.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietDichVuUuDaiEntity>()
                .HasOne(c => c.DichVuUuDais)
                .WithMany(d => d.ChiTietDichVuUuDais)
                .HasForeignKey(c => c.MaDichVuUuDai)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Menu
            modelBuilder.Entity<ChiTietMenuEntity>()
                .HasKey(e => new { e.MaTiec, e.MaMenu });
            modelBuilder.Entity<ChiTietMenuEntity>()
                .HasOne(c => c.DatTiecs)
                .WithMany(t => t.ChiTietMenus)
                .HasForeignKey(c => c.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietMenuEntity>()
                .HasOne(c => c.Menus)
                .WithMany(d => d.ChiTietMenus)
                .HasForeignKey(c => c.MaMenu)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Nuoc Uong
            modelBuilder.Entity<ChiTietNuocUongEntity>()
                .HasKey(e => new { e.MaTiec, e.MaNuoc });
            modelBuilder.Entity<ChiTietNuocUongEntity>()
                .HasOne(c => c.DatTiecs)
                .WithMany(t => t.ChiTietNuocUongs)
                .HasForeignKey(c => c.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietNuocUongEntity>()
                .HasOne(c => c.Nuocs)
                .WithMany(d => d.ChiTietNuocUongs)
                .HasForeignKey(c => c.MaNuoc)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Phu Thu Dich Vu
            modelBuilder.Entity<ChiTietPhuThuDichVuEntity>()
                .HasKey(e => new { e.MaPhuThu, e.MaDichVuTinhPhi });
            modelBuilder.Entity<ChiTietPhuThuDichVuEntity>()
                .HasOne(c => c.PhuThus)
                .WithMany(t => t.ChiTietPhuThuDichVus)
                .HasForeignKey(c => c.MaPhuThu)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietPhuThuDichVuEntity>()
                .HasOne(c => c.DichVuTinhPhis)
                .WithMany(d => d.ChiTietPhuThuDichVus)
                .HasForeignKey(c => c.MaDichVuTinhPhi)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Phu Thu Mon An
            modelBuilder.Entity<ChiTietPhuThuMonAnEntity>()
                .HasKey(e => new { e.MaPhuThu, e.MaMonAn });
            modelBuilder.Entity<ChiTietPhuThuMonAnEntity>()
                .HasOne(c => c.PhuThus)
                .WithMany(t => t.ChiTietPhuThuMonAns)
                .HasForeignKey(c => c.MaPhuThu)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietPhuThuMonAnEntity>()
                .HasOne(c => c.MonAns)
                .WithMany(d => d.ChiTietPhuThuMonAns)
                .HasForeignKey(c => c.MaMonAn)
                .OnDelete(DeleteBehavior.Cascade);

            // Chi Tiet Phu Thu Nuoc
            modelBuilder.Entity<ChiTietPhuThuNuocEntity>()
                .HasKey(e => new { e.MaPhuThu, e.MaNuoc });
            modelBuilder.Entity<ChiTietPhuThuNuocEntity>()
                .HasOne(c => c.PhuThus)
                .WithMany(t => t.ChiTietPhuThuNuocs)
                .HasForeignKey(c => c.MaPhuThu)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ChiTietPhuThuNuocEntity>()
                .HasOne(c => c.Nuocs)
                .WithMany(d => d.ChiTietPhuThuNuocs)
                .HasForeignKey(c => c.MaNuoc)
                .OnDelete(DeleteBehavior.Cascade);

            // Danh Gia
            modelBuilder.Entity<DanhGiaEntity>()
                .HasKey(d => d.MaDanhGia);
            modelBuilder.Entity<DanhGiaEntity>()
                .HasOne(d => d.KhachHangs)
                .WithMany(k => k.DanhGias) // 1-n
                .HasForeignKey(d => d.MaKhachHang);

            // Dat Tiec
            modelBuilder.Entity<DatTiecEntity>()
                .HasKey(d => d.MaTiec);
            modelBuilder.Entity<DatTiecEntity>() 
                .HasOne(d => d.KhachHangs)
                .WithMany(k => k.DatTiecs) // 1-n
                .HasForeignKey(d => d.MaKhachHang) 
                .OnDelete(DeleteBehavior.Cascade);

            // Dich Vu
            modelBuilder.Entity<DichVuEntity>()
                .HasKey(e => new { e.MaDichVu });
            modelBuilder.Entity<DichVuEntity>()
                .HasOne(c => c.LoaiDichVus)
                .WithMany(t => t.DichVus)
                .HasForeignKey(c => c.MaLoaiDichVu)
                .OnDelete(DeleteBehavior.Cascade);

            // Dich Vu Tinh Phi
            modelBuilder.Entity<DichVuTinhPhiEntity>()
                .HasKey(e => new { e.MaDichVuTinhPhi });
            modelBuilder.Entity<DichVuTinhPhiEntity>()
                .HasOne(c => c.DichVus)
                .WithMany(t => t.DichVuTinhPhis)
                .HasForeignKey(c => c.MaDichVu)
                .OnDelete(DeleteBehavior.Cascade);

            // Dich Vu Uu Dai
            modelBuilder.Entity<DichVuUuDaiEntity>()
                .HasKey(e => new { e.MaDichVuUuDai });
            modelBuilder.Entity<DichVuUuDaiEntity>()
                .HasOne(c => c.DichVus)
                .WithMany(t => t.DichVuUuDais)
                .HasForeignKey(c => c.MaDichVu)
                .OnDelete(DeleteBehavior.Cascade);

            // Khach Hang
            modelBuilder.Entity<KhachHangEntity>()
                .HasKey(d => d.MaKhachHang);

            // Hoa Don
            modelBuilder.Entity<HoaDonEntity>()
                .HasKey(d => d.MaHoaDon);
             modelBuilder.Entity<DatTiecEntity>()
                .HasOne(d => d.HoaDons)
                .WithOne(h => h.DatTiecs)
                .HasForeignKey<HoaDonEntity>(h => h.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);

            // Lich Sanh Tiec
            modelBuilder.Entity<LichSanhTiecEntity>()
               .HasKey(e => new { e.MaTiec, e.MaSanh });
            modelBuilder.Entity<LichSanhTiecEntity>()
                .HasOne(d => d.DatTiecs)
                .WithMany(k => k.LichSanhTiecs) 
                .HasForeignKey(d => d.MaTiec)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LichSanhTiecEntity>()
                .HasOne(d => d.Sanhs)
                .WithMany(k => k.LichSanhTiecs) 
                .HasForeignKey(k => k.MaSanh)
                .OnDelete(DeleteBehavior.Cascade);

            // Loai Dich Vu
            modelBuilder.Entity<LoaiDichVuEntity>()
                .HasKey(d => d.MaLoaiDichVu);

            // Loai Mon An
            modelBuilder.Entity<LoaiMonAnEntity>()
                .HasKey(d => d.MaLoaiMonAn);

            // Loai Nuoc
            modelBuilder.Entity<LoaiNuocEntity>()
                .HasKey(d => d.MaLoaiNuoc);

            // Menu
            modelBuilder.Entity<MenuEntity>()
                .HasKey(d => d.MaMenu);

            // Mon An
            modelBuilder.Entity<MonAnEntity>()
                .HasKey(d => d.MaMonAn);
            modelBuilder.Entity<MonAnEntity>()
                .HasOne(h => h.LoaiMonAns)
                .WithMany(d => d.MonAns)
                .HasForeignKey(h => h.MaLoaiMonAn);

            // Mon An Trong Menu
            modelBuilder.Entity<MonAnTrongMenuEntity>()
               .HasKey(e => new { e.MaMenu, e.MaMonAn });
            modelBuilder.Entity<MonAnTrongMenuEntity>()
                .HasOne(d => d.Menus)
                .WithMany(k => k.MonAnTrongMenus) 
                .HasForeignKey(d => d.MaMenu)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MonAnTrongMenuEntity>()
                .HasOne(d => d.MonAns)
                .WithMany(k => k.MonAnTrongMenus) 
                .HasForeignKey(k => k.MaMonAn)
                .OnDelete(DeleteBehavior.Cascade);

            // Nuoc
            modelBuilder.Entity<NuocEntity>()
                .HasKey(d => d.MaNuoc);
            modelBuilder.Entity<NuocEntity>()
                .HasOne(h => h.LoaiNuocs)
                .WithMany(d => d.Nuocs)
                .HasForeignKey(h => h.MaLoaiNuoc);

            // Nhan Vien
            modelBuilder.Entity<NhanVienEntity>()
               .HasKey(d => d.MaNhanVien);

            // Nhan Vien Trong Tiec
            modelBuilder.Entity<NhanVienTrongTiecEntity>()
               .HasKey(e => new { e.MaTiec, e.MaNhanVien });
            modelBuilder.Entity<NhanVienTrongTiecEntity>()
                .HasOne(h => h.DatTiecs)
                .WithMany(d => d.NhanVienTrongTiecs)
                .HasForeignKey(h => h.MaTiec);
            modelBuilder.Entity<NhanVienTrongTiecEntity>()
                .HasOne(h => h.NhanViens)
                .WithMany(d => d.NhanVienTrongTiecs)
                .HasForeignKey(h => h.MaNhanVien);

            // Phu Thu
            modelBuilder.Entity<PhuThuEntity>()
               .HasKey(e => new { e.MaPhuThu });
            modelBuilder.Entity<PhuThuEntity>()
                .HasOne(d => d.HoaDons)
                .WithMany(k => k.PhuThus)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.Cascade);

            // Sanh
            modelBuilder.Entity<SanhEntity>()
               .HasKey(d => d.MaSanh);

            // SoDienThoai
            modelBuilder.Entity<SoDienThoaiEntity>()
               .HasKey(d => d.DauSo);

            // Phân Quyền
            modelBuilder.Entity<AccessTokenEntity>().HasNoKey();
            modelBuilder.Entity<RefreshTokenEntity>()
                .HasKey(e => new { e.Token, e.userName });
            modelBuilder.Entity<NguoiDungEntity>()
                .HasKey(e => e.userName );
        }
    }
}
