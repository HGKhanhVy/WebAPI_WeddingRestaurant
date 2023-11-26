using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.NhanVienTrongTiec;

namespace WeddingRestaurant.Contract.Service
{
    public interface INhanVienTrongTiecService :
       Base.ICreateable<NhanVienTrongTiecModel, string>,
       Base.IUpdateable2Fields<NhanVienTrongTiecModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<NhanVienTrongTiecEntity, string, string>,
       Base.ICounteable<NhanVienTrongTiecModel, int>
    {
    }
}
