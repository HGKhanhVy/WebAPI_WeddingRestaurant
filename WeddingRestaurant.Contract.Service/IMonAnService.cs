using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.MonAn;

namespace WeddingRestaurant.Contract.Service
{
    public interface IMonAnService :
       Base.ICreateable<MonAnModel, string>,
       Base.IUpdateable<MonAnModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<MonAnEntity, string>,
       Base.ICounteable<MonAnModel, int>
    {
    }
}
