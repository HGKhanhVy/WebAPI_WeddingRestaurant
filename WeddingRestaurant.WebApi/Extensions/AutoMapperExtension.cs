using WeddingRestaurant.Mapper;

namespace WeddingRestaurant.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ChiTietDichVuTinhPhiProfile());
                cfg.AddProfile(new ChiTietDichVuUuDaiProfile());
                cfg.AddProfile(new ChiTietMenuProfile());
                cfg.AddProfile(new ChiTietNuocUongProfile());
                cfg.AddProfile(new ChiTietPhuThuDichVuProfile());
                cfg.AddProfile(new ChiTietPhuThuMonAnProfile());
                cfg.AddProfile(new ChiTietPhuThuNuocProfile());
                cfg.AddProfile(new DatTiecProfile());
                cfg.AddProfile(new DichVuProfile());
                cfg.AddProfile(new DichVuTinhPhiProfile());
                cfg.AddProfile(new DichVuUuDaiProfile());
                cfg.AddProfile(new HoaDonProfile());
                cfg.AddProfile(new KhachHangProfile());
                cfg.AddProfile(new LichSanhTiecProfile());
                cfg.AddProfile(new LoaiDichVuProfile());
                cfg.AddProfile(new LoaiMonAnProfile());
                cfg.AddProfile(new LoaiNuocProfile());
                cfg.AddProfile(new MenuProfile());
                cfg.AddProfile(new MonAnProfile());
                cfg.AddProfile(new MonAnTrongMenuProfile());
                cfg.AddProfile(new NuocProfile());
                cfg.AddProfile(new NhanVienProfile());
                cfg.AddProfile(new NhanVienTrongTiecProfile());
                cfg.AddProfile(new PhuThuProfile());
                cfg.AddProfile(new SanhProfile());
                cfg.AddProfile(new SoDienThoaiProfile());
                cfg.AddProfile(new NguoiDungProfile());
                cfg.AddProfile(new LoginProfile());
                cfg.AddProfile(new TokenProfile());
                cfg.AddProfile(new RefreshTokenProfile());
                cfg.AddProfile(new AccessTokenProfile());
            });
            return services;
        }
    }
}
