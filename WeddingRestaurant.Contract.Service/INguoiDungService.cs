using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Service
{
    public interface INguoiDungService :
        Base.IGetable<NguoiDungEntity, string>,
        Base.ICreateable<NguoiDungModel, string>,
        Base.IUpdateable<NguoiDungModel, string>,
        Base.IDeleteable<string, bool>
    {
    }
}
