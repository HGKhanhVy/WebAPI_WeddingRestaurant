using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.LichSanhTiec;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietDichVuTinhPhiService :
       Base.ICreateable<ChiTietDichVuTinhPhiModel, string>,
       Base.IUpdateable2Fields<ChiTietDichVuTinhPhiModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietDichVuTinhPhiEntity, string, string>,
       Base.ICounteable<ChiTietDichVuTinhPhiModel, int>
    {
    }
}
