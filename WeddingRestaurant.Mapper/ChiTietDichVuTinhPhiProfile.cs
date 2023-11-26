using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietDichVuTinhPhi;
using WeddingRestaurant.Core.Models.ChiTietMenu;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietDichVuTinhPhiProfile : Profile
    {
        public ChiTietDichVuTinhPhiProfile()
        {
            CreateMap<ChiTietDichVuTinhPhiModel, ChiTietDichVuTinhPhiEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ForMember(x => x.MaDichVuTinhPhi, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
