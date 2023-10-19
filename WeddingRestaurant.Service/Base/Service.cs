using Microsoft.Extensions.DependencyInjection;
using WeddingRestaurant.Contract.Repository.Infrastructure;

namespace WeddingRestaurant.Service.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected Service(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
