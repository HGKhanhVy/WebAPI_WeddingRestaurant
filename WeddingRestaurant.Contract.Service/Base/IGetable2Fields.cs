﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Login;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface IGetable2Fields<T, in TKey, in T2Key> where T : class, new()
    {
        ICollection<T> GetAllAsync();
        T GetByKeyIdAsync(TKey keyId, T2Key id);
        ICollection<T> GetAllByKey1Async(TKey id);
        ICollection<T> GetAllByKey2Async(T2Key id);
    }
}
