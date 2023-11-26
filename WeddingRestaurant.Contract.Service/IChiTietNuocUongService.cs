using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietNuocUongService :
       Base.ICreateable<ChiTietNuocUongModel, string>,
       Base.IUpdateable2Fields<ChiTietNuocUongModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietNuocUongEntity, string, string>,
       Base.ICounteable<ChiTietNuocUongModel, int>
    {
    }
}
