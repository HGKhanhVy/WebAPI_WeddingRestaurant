using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Contract.Service.Base
{
    public interface ICheckToken
    {
        RefreshTokenEntity CheckExistsToken(TokenModel model);
    }
}
