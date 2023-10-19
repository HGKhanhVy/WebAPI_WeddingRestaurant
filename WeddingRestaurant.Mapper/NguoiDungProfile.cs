using AutoMapper;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.NguoiDung;

namespace WeddingRestaurant.Mapper
{
    public class NguoiDungProfile : Profile
    {
        public NguoiDungProfile()
        {
            CreateMap<NguoiDungModel, NguoiDungEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}

