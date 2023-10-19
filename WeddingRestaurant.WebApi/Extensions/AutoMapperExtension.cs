using WeddingRestaurant.Mapper;

namespace WeddingRestaurant.WebApi.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new ChiTietDichVuProfile());
                cfg.AddProfile(new ChiTietMenuProfile());
                cfg.AddProfile(new ChiTietNuocUongProfile());
                cfg.AddProfile(new DatTiecProfile());
                cfg.AddProfile(new DichVuProfile());
                cfg.AddProfile(new KhachHangProfile());
                cfg.AddProfile(new KhuyenMaiProfile());
                cfg.AddProfile(new LichSanhTiecProfile());
                cfg.AddProfile(new LoaiMonAnProfile());
                cfg.AddProfile(new LoaiNuocProfile());
                cfg.AddProfile(new MenuProfile());
                cfg.AddProfile(new MonAnProfile());
                cfg.AddProfile(new MonAnTrongMenuProfile());
                cfg.AddProfile(new NuocProfile());
                cfg.AddProfile(new SanhProfile());
                cfg.AddProfile(new SuDungKhuyenMaiProfile());
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
