using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietNuocUongProfile : Profile
    {
        public ChiTietNuocUongProfile()
        {
            CreateMap<ChiTietNuocUongModel, ChiTietNuocUongEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
