using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models.Nuoc;

namespace WeddingRestaurant.Contract.Service
{
    public interface INhanVienService :
       Base.ICreateable<NhanVienModel, string>,
       Base.IUpdateable<NhanVienModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NhanVienEntity, string>,
       Base.ICounteable<NhanVienModel, int>,
       Base.ILogin<NhanVienEntity, string, string>
    {
    }
}
