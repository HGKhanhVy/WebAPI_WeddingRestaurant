using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.LoaiNuoc;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class LoaiNuocProfile : Profile
    {
        public LoaiNuocProfile()
        {
            CreateMap<LoaiNuocModel, LoaiNuocEntity>()
                .ForMember(x => x.MaLoaiNuoc, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
