using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Contract.Repository.Interface;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Repository.Infrastructure;
using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartoon.Contract.Repository.Interface;

namespace WeddingRestaurant.Repository
{
    [ScopedDependency(ServiceType = typeof(ILoginRepository))]
    public class LoginRepository : Repository<LoginEntity>, ILoginRepository
    {
        public LoginRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
