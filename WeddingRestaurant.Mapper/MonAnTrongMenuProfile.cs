using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.MonAnTrongMenu;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class MonAnTrongMenuProfile : Profile
    {
        public MonAnTrongMenuProfile()
        {
            CreateMap<MonAnTrongMenuModel, MonAnTrongMenuEntity>()
                .ForMember(x => x.MaMenu, opt => opt.Ignore())
                .ForMember(x => x.MaMonAn, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
