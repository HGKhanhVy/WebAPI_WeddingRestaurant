using WeddingRestaurant.Contract.Repository.IBase;
using WeddingRestaurant.Contract.Repository.Models;

namespace WeddingRestaurant.Contract.Repository.Infrastructure
{
    public interface IRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
    }
}
