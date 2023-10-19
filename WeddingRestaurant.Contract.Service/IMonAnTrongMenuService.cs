using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.MonAnTrongMenu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IMonAnTrongMenuService :
       Base.ICreateable<MonAnTrongMenuModel, string>,
       Base.IUpdateable2Fields<MonAnTrongMenuModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<MonAnTrongMenuEntity, string, string>,
       Base.ICounteable<MonAnTrongMenuModel, int>
    {
    }
}
