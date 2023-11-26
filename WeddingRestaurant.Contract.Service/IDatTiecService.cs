using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DatTiec;

namespace WeddingRestaurant.Contract.Service
{
    public interface IDatTiecService :
       Base.ICreateable<DatTiecModel, string>,
       Base.IUpdateable<DatTiecModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DatTiecEntity, string>,
       Base.ICounteable<DatTiecModel, int>,
       Base.ISortable<DatTiecEntity>,
       Base.IUpdateStatus
    {
    }
}
