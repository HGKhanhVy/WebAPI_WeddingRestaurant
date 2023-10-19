using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.SuDungKhuyenMai;

namespace WeddingRestaurant.Contract.Service
{
    public interface ISuDungKhuyenMaiService :
       Base.ICreateable<SuDungKhuyenMaiModel, string>,
       Base.IUpdateable2Fields<SuDungKhuyenMaiModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<SuDungKhuyenMaiEntity, string, string>,
       Base.ICounteable<SuDungKhuyenMaiModel, int>
    {
    }
}
