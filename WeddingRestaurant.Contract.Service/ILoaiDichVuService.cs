using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.HoaDon;
using WeddingRestaurant.Core.Models.LoaiDichVu;

namespace WeddingRestaurant.Contract.Service
{
    public interface ILoaiDichVuService :
       Base.ICreateable<LoaiDichVuModel, string>,
       Base.IUpdateable<LoaiDichVuModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LoaiDichVuEntity, string>,
       Base.ICounteable<LoaiDichVuModel, int>
    {
    }
}
