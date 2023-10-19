using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.Menu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IMenuService :
       Base.ICreateable<MenuModel, string>,
       Base.IUpdateable<MenuModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<MenuEntity, string>,
       Base.ICounteable<MenuModel, int>
    {
    }
}
