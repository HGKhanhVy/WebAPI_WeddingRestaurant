using Azure.Core;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Service
{
    public interface ITokenService :
        Base.ISaveTokenDB
    {
    }
}
