using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models.PhuThu;

namespace WeddingRestaurant.Contract.Service
{
    public interface IPhuThuService :
       Base.ICreateable<PhuThuModel, string>,
       Base.IUpdateable<PhuThuModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<PhuThuEntity, string>,
       Base.ICounteable<PhuThuModel, int>
    {
    }
}
