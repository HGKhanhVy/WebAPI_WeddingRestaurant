using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietNuocUong;
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietPhuThuDichVuProfile : Profile
    {
        public ChiTietPhuThuDichVuProfile()
        {
            CreateMap<ChiTietPhuThuDichVuModel, ChiTietPhuThuDichVuEntity>()
                .ForMember(x => x.MaPhuThu, opt => opt.Ignore())
                .ForMember(x => x.MaDichVuTinhPhi, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
