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
    [ScopedDependency(ServiceType = typeof(ILoaiNuocRepository))]
    public class LoaiNuocRepository : Repository<LoaiNuocEntity>, ILoaiNuocRepository
    {
        public LoaiNuocRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
