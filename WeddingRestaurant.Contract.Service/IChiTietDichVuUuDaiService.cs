using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.ChiTietDichVuUuDai;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietDichVuUuDaiService :
       Base.ICreateable<ChiTietDichVuUuDaiModel, string>,
       Base.IUpdateable2Fields<ChiTietDichVuUuDaiModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietDichVuUuDaiEntity, string, string>,
       Base.ICounteable<ChiTietDichVuUuDaiModel, int>
    {
    }
}
