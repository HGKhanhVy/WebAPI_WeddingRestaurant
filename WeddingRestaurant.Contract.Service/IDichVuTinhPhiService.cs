using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVu;
using WeddingRestaurant.Core.Models.DichVuTinhPhi;

namespace WeddingRestaurant.Contract.Service
{
    public interface IDichVuTinhPhiService :
       Base.ICreateable<DichVuTinhPhiModel, string>,
       Base.IUpdateable<DichVuTinhPhiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<DichVuTinhPhiEntity, string>,
       Base.ICounteable<DichVuTinhPhiModel, int>
    {
    }
}
