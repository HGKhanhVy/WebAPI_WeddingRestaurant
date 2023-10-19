using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.Nuoc;

namespace WeddingRestaurant.Contract.Service
{
    public interface INuocService :
       Base.ICreateable<NuocModel, string>,
       Base.IUpdateable<NuocModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NuocEntity, string>,
       Base.ICounteable<NuocModel, int>
    {
    }
}
