using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.KhachHang;
using WeddingRestaurant.Core.Models.LoaiDichVu;

namespace WeddingRestaurant.Mapper
{
    public class LoaiDichVuProfile : Profile
    {
        public LoaiDichVuProfile()
        {
            CreateMap<LoaiDichVuModel, LoaiDichVuEntity>()
                .ForMember(x => x.MaLoaiDichVu, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
