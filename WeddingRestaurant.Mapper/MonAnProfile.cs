using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.MonAn;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class MonAnProfile : Profile
    {
        public MonAnProfile()
        {
            CreateMap<MonAnModel, MonAnEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
