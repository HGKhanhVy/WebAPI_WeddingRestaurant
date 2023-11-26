using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietPhuThuMonAnService :
       Base.ICreateable<ChiTietPhuThuMonAnModel, string>,
       Base.IUpdateable2Fields<ChiTietPhuThuMonAnModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietPhuThuMonAnEntity, string, string>,
       Base.ICounteable<ChiTietPhuThuMonAnModel, int>
    {
    }
}
