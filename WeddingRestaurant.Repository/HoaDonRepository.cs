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
    [ScopedDependency(ServiceType = typeof(IHoaDonRepository))]
    public class HoaDonRepository : Repository<HoaDonEntity>, IHoaDonRepository
    {
        public HoaDonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
