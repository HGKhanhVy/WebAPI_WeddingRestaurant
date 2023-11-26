using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NhanVien;
using WeddingRestaurant.Core.Models.PhuThu;

namespace WeddingRestaurant.Mapper
{
    public class PhuThuProfile : Profile
    {
        public PhuThuProfile()
        {
            CreateMap<PhuThuModel, PhuThuEntity>()
                .ForMember(x => x.MaPhuThu, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
