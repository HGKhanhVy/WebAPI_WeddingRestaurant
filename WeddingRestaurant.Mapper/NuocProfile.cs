using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Nuoc;
using WeddingRestaurant.Core.Models.Token;

namespace WeddingRestaurant.Mapper
{
    public class NuocProfile : Profile
    {
        public NuocProfile()
        {
            CreateMap<NuocModel, NuocEntity>()
                .ForMember(x => x.MaNuoc, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
