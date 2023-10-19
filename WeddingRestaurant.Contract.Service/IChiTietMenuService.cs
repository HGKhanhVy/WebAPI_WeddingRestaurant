using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.ChiTietMenu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietMenuService :
       Base.ICreateable<ChiTietMenuModel, string>,
       Base.IUpdateable2Fields<ChiTietMenuModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietMenuEntity, string, string>,
       Base.ICounteable<ChiTietMenuModel, int>
    {
    }
}
