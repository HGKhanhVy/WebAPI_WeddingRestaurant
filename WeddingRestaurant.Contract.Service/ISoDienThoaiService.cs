using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Sanh;
using WeddingRestaurant.Core.Models.SoDienThoai;

namespace WeddingRestaurant.Contract.Service
{
    public interface ISoDienThoaiService :
       Base.ICreateable<SoDienThoaiModel, string>,
       Base.IUpdateable<SoDienThoaiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<SoDienThoaiEntity, string>
    {
    }
}
