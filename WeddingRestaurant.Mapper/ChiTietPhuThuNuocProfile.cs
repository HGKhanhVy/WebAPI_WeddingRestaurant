using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;
using WeddingRestaurant.Core.Models.ChiTietPhuThuNuoc;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietPhuThuNuocProfile : Profile
    {
        public ChiTietPhuThuNuocProfile()
        {
            CreateMap<ChiTietPhuThuNuocModel, ChiTietPhuThuNuocEntity>()
                .ForMember(x => x.MaPhuThu, opt => opt.Ignore())
                .ForMember(x => x.MaNuoc, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
