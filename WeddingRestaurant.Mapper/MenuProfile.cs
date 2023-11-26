using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Menu;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuModel, MenuEntity>()
                .ForMember(x => x.MaMenu, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
