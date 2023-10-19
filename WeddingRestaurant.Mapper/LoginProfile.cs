using AutoMapper;
using WeddingRestaurant.Contract.Repository.Models;
using WeddingRestaurant.Core.Models.Login;
using WeddingRestaurant.Core.Models.NguoiDung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRestaurant.Mapper
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginModel, LoginEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
