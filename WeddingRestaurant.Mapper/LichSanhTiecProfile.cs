using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.LichSanhTiec;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class LichSanhTiecProfile : Profile
    {
        public LichSanhTiecProfile()
        {
            CreateMap<LichSanhTiecModel, LichSanhTiecEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ForMember(x => x.MaSanh, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
