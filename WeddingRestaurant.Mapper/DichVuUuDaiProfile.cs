using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DichVuTinhPhi;
using WeddingRestaurant.Core.Models.DichVuUuDai;

namespace WeddingRestaurant.Mapper
{
    public class DichVuUuDaiProfile : Profile
    {
        public DichVuUuDaiProfile()
        {
            CreateMap<DichVuUuDaiModel, DichVuUuDaiEntity>()
                .ForMember(x => x.MaDichVuUuDai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
