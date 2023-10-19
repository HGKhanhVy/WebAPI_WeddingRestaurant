using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.KhuyenMai;

namespace WeddingRestaurant.Contract.Service
{
    public interface IKhuyenMaiService :
       Base.ICreateable<KhuyenMaiModel, string>,
       Base.IUpdateable<KhuyenMaiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KhuyenMaiEntity, string>,
       Base.ICounteable<KhuyenMaiModel, int>
    {
    }
}
