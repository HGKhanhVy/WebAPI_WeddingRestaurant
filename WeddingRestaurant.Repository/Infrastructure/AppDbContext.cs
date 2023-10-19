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
                connectionString = "Data Source=KHANHVY\\SQLEXPRESS;initial Catalog=DB_WeddingRestaurant;user id=sa;password=123;Trusted_Connection=True;Trust Server Certificate=True; Integrated Security=false";

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

            modelBuilder.Entity<ChiTietDichVuEntity>()
                .HasKey(e => new { e.MaTiec, e.MaDichVu });

            modelBuilder.Entity<ChiTietMenuEntity>()
                .HasKey(e => new { e.MaTiec, e.MaMenu });

            modelBuilder.Entity<ChiTietNuocUongEntity>()
                .HasKey(e => new { e.MaTiec, e.MaNuoc });

            modelBuilder.Entity<LichSanhTiecEntity>()
               .HasKey(e => new { e.MaTiec, e.MaSanh });

            modelBuilder.Entity<MonAnTrongMenuEntity>()
               .HasKey(e => new { e.MaMenu, e.MaMonAn });

            modelBuilder.Entity<SuDungKhuyenMaiEntity>()
               .HasKey(e => new { e.MaTiec, e.MaKM });
        }
    }
}
