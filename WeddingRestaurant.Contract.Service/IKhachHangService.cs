using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.KhachHang;

namespace WeddingRestaurant.Contract.Service
{
    public interface IKhachHangService :
       Base.ICreateable<KhachHangModel, string>,
       Base.IUpdateable<KhachHangModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KhachHangEntity, string>,
       Base.ICounteable<KhachHangModel, int>
    {
    }
}
