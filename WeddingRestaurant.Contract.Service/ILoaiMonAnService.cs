﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.LoaiMonAn;

namespace WeddingRestaurant.Contract.Service
{
    public interface ILoaiMonAnService :
       Base.ICreateable<LoaiMonAnModel, string>,
       Base.IUpdateable<LoaiMonAnModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LoaiMonAnEntity, string>,
       Base.ICounteable<LoaiMonAnModel, int>
    {
    }
}
