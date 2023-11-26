using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVu;
using WeddingRestaurant.Core.Models.DichVuTinhPhi;

namespace WeddingRestaurant.Mapper
{
    public class DichVuTinhPhiProfile : Profile
    {
        public DichVuTinhPhiProfile()
        {
            CreateMap<DichVuTinhPhiModel, DichVuTinhPhiEntity>()
                .ForMember(x => x.MaDichVuTinhPhi, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
