using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietMenu;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietMenuProfile : Profile
    {
        public ChiTietMenuProfile()
        {
            CreateMap<ChiTietMenuModel, ChiTietMenuEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ForMember(x => x.MaMenu, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
