using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Sanh;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class SanhProfile : Profile
    {
        public SanhProfile()
        {
            CreateMap<SanhModel, SanhEntity>()
                .ForMember(x => x.MaSanh, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
