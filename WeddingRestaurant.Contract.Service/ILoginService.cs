using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace WeddingRestaurant.Contract.Service
{
    public interface ILoginService :
       Base.ICreateable<LoginModel, string>
    {
    }
}
