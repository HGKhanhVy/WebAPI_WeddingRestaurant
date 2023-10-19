using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietDichVuService :
       Base.ICreateable<ChiTietDichVuModel, string>,
       Base.IUpdateable2Fields<ChiTietDichVuModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietDichVuEntity, string, string>,
       Base.ICounteable<ChiTietDichVuModel, string>
    {
    }
}
