using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.LoaiNuoc;

namespace WeddingRestaurant.Contract.Service
{
    public interface ILoaiNuocService :
       Base.ICreateable<LoaiNuocModel, string>,
       Base.IUpdateable<LoaiNuocModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LoaiNuocEntity, string>,
       Base.ICounteable<LoaiNuocModel, int>
    {
    }
}
