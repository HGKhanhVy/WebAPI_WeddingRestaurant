using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.KhachHang;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class KhachHangProfile : Profile
    {
        public KhachHangProfile()
        {
            CreateMap<KhachHangModel, KhachHangEntity>()
                .ForMember(x => x.MaKhachHang, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
