using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.HoaDon;
using WeddingRestaurant.Core.Models.KhachHang;

namespace WeddingRestaurant.Contract.Service
{
    public interface IHoaDonService :
       Base.ICreateable<HoaDonModel, string>,
       Base.IUpdateable<HoaDonModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HoaDonEntity, string>,
       Base.ICounteable<HoaDonModel, int>
    {
    }
}
