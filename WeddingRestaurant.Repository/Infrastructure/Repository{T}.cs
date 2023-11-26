using WeddingRestaurant.Contract.Repository.IBase;
using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Repository.Base;

namespace WeddingRestaurant.Repository.Infrastructure
{
    public abstract class Repository<T> : BaseRepository<T>, IRepository<T>, IBaseRepository<T> where T : Entity, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
