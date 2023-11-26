using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVuUuDai;
using WeddingRestaurant.Core.Models.HoaDon;

namespace WeddingRestaurant.Mapper
{
    public class HoaDonProfile : Profile
    {
        public HoaDonProfile()
        {
            CreateMap<HoaDonModel, HoaDonEntity>()
                .ForMember(x => x.MaHoaDon, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
