using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models.NhanVienTrongTiec;

namespace WeddingRestaurant.Mapper
{
    public class NhanVienTrongTiecProfile : Profile
    {
        public NhanVienTrongTiecProfile()
        {
            CreateMap<NhanVienTrongTiecModel, NhanVienTrongTiecEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ForMember(x => x.MaNhanVien, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
