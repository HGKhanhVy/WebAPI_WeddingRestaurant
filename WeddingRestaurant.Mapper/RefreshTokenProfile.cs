using AutoMapper;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.RefreshToken;
using WeddingRestaurant.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Mapper
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshTokenModel, RefreshTokenEntity>()
                .ForMember(x => x.userName, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
