using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Sanh;

namespace WeddingRestaurant.Contract.Service
{
    public interface ISanhService :
       Base.ICreateable<SanhModel, string>,
       Base.IUpdateable<SanhModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<SanhEntity, string>,
       Base.ICounteable<SanhModel, int>,
       Base.IPrintForSanh<SanhModel, string>
    {
    }
}
