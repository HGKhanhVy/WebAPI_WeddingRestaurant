using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVuTinhPhi;
using WeddingRestaurant.Core.Models.DichVuUuDai;

namespace WeddingRestaurant.Contract.Service
{
    public interface IDichVuUuDaiService :
       Base.ICreateable<DichVuUuDaiModel, string>,
       Base.IUpdateable<DichVuUuDaiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DichVuUuDaiEntity, string>,
       Base.ICounteable<DichVuUuDaiModel, int>
    {
    }
}
