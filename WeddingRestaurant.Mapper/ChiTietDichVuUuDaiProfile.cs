using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.ChiTietDichVuUuDai;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietDichVuUuDaiProfile : Profile
    {
        public ChiTietDichVuUuDaiProfile()
        {
            CreateMap<ChiTietDichVuUuDaiModel, ChiTietDichVuUuDaiEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ForMember(x => x.MaDichVuUuDai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
