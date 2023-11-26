using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IChiTietPhuThuDichVuService :
       Base.ICreateable<ChiTietPhuThuDichVuModel, string>,
       Base.IUpdateable2Fields<ChiTietPhuThuDichVuModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<ChiTietPhuThuDichVuEntity, string, string>,
       Base.ICounteable<ChiTietPhuThuDichVuModel, int>
    {
    }
}
