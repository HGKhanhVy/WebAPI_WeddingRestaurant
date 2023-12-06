using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.DatTiec;
using WeddingRestaurant.Core.Models.LoaiDichVu;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class DatTiecProfile : Profile
    {
        public DatTiecProfile()
        {
            CreateMap<DatTiecModel, DatTiecEntity>()
                .ForMember(x => x.MaTiec, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
