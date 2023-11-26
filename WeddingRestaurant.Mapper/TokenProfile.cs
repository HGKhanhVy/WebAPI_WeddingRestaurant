using AutoMapper;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NguoiDung;
using WeddingRestaurant.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Mapper
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<TokenModel, TokenEntity>()
                .ForMember(x => x.AccessToken, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
