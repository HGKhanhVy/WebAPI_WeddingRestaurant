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
    [ScopedDependency(ServiceType = typeof(IChiTietPhuThuDichVuRepository))]
    public class ChiTietPhuThuDichVuRepository : Repository<ChiTietPhuThuDichVuEntity>, IChiTietPhuThuDichVuRepository
    {
        public ChiTietPhuThuDichVuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
