using AutoMapper;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.AccessToken;
using WeddingRestaurant.Core.Models.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Mapper
{
    public class AccessTokenProfile : Profile
    {
        public AccessTokenProfile()
        {
            CreateMap<AccessTokenModel, AccessTokenEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
