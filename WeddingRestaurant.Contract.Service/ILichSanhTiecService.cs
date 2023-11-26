using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.LichSanhTiec;

namespace WeddingRestaurant.Contract.Service
{
    public interface ILichSanhTiecService :
       Base.ICreateable<LichSanhTiecModel, string>,
       Base.IUpdateable2Fields<LichSanhTiecModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<LichSanhTiecEntity, string, string>,
       Base.ICounteable<LichSanhTiecModel, int>,
       Base.IPrintForLichSanhTiec<LichSanhTiecEntity, string, string>,
       Base.ISortable<LichSanhTiecEntity>
    {
    }
}
