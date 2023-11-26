using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models.Nuoc;

namespace WeddingRestaurant.Mapper
{
    public class NhanVienProfile : Profile
    {
        public NhanVienProfile()
        {
            CreateMap<NhanVienModel, NhanVienEntity>()
                .ForMember(x => x.MaNhanVien, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
