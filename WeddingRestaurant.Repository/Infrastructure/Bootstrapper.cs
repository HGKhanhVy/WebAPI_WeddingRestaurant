using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using WeddingRestaurant.Contract.Repository.Infrastructure;

namespace WeddingRestaurant.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IBootstrapper))]
    public class Bootstrapper : IBootstrapper
    {
        private readonly IDbContext _dbContext;

        public Bootstrapper(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
