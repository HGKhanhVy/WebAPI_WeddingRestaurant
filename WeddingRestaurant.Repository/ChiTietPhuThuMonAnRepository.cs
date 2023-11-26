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
    [ScopedDependency(ServiceType = typeof(IChiTietPhuThuMonAnRepository))]
    public class ChiTietPhuThuMonAnRepository : Repository<ChiTietPhuThuMonAnEntity>, IChiTietPhuThuMonAnRepository
    {
        public ChiTietPhuThuMonAnRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
