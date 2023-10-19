using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVu;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietDichVuProfile : Profile
    {
        public ChiTietDichVuProfile()
        {
            CreateMap<ChiTietDichVuModel, ChiTietDichVuEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
