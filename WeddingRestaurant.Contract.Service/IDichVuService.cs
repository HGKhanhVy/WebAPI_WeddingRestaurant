using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IDichVuService :
       Base.ICreateable<DichVuModel, string>,
       Base.IUpdateable<DichVuModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DichVuEntity, string>,
       Base.ICounteable<DichVuModel, int>
    {
    }
}
