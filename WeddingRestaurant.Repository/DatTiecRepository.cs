using Cartoon.Contract.Repository.Interface;
using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Contract.Repository.Interface;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Repository.Infrastructure;

namespace WeddingRestaurant.Repository
{
    [ScopedDependency(ServiceType = typeof(IDatTiecRepository))]
    public class DatTiecRepository : Repository<DatTiecEntity>, IDatTiecRepository
    {
        public DatTiecRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
