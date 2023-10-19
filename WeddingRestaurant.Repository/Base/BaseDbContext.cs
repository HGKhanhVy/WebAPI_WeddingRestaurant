using Microsoft.EntityFrameworkCore;
using WeddingRestaurant.Contract.Repository.Infrastructure;

namespace WeddingRestaurant.Repository.Base
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext()
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }

        protected BaseDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }
    }
}
