using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Sanh;
using WeddingRestaurant.Core.Models.SoDienThoai;

namespace WeddingRestaurant.Mapper
{
    public class SoDienThoaiProfile : Profile
    {
        public SoDienThoaiProfile()
        {
            CreateMap<SoDienThoaiModel, SoDienThoaiEntity>()
                .ForMember(x => x.DauSo, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
