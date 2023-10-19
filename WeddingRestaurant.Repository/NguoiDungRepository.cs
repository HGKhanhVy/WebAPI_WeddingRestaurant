﻿using WeddingRestaurant.Contract.Repository.Infrastructure;
using WeddingRestaurant.Contract.Repository.Interface;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Repository.Infrastructure;
using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Repository
{
    [ScopedDependency(ServiceType = typeof(INguoiDungRepository))]
    public class NguoiDungRepository : Repository<NguoiDungEntity>, INguoiDungRepository
    {
        public NguoiDungRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
