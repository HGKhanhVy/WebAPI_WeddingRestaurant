using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;
using WeddingRestaurant.Core.Models.ChiTietPhuThuNuoc;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietPhuThuNuocService :
       Base.ICreateable<ChiTietPhuThuNuocModel, string>,
       Base.IUpdateable2Fields<ChiTietPhuThuNuocModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietPhuThuNuocEntity, string, string>,
       Base.ICounteable<ChiTietPhuThuNuocModel, int>
    {
    }
}
