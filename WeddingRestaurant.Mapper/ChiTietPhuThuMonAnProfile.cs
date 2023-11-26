using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.ChiTietPhuThuDichVu;
using WeddingRestaurant.Core.Models.ChiTietPhuThuMonAn;

namespace WeddingRestaurant.Mapper
{
    public class ChiTietPhuThuMonAnProfile : Profile
    {
        public ChiTietPhuThuMonAnProfile()
        {
            CreateMap<ChiTietPhuThuMonAnModel, ChiTietPhuThuMonAnEntity>()
                .ForMember(x => x.MaPhuThu, opt => opt.Ignore())
                .ForMember(x => x.MaMonAn, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
