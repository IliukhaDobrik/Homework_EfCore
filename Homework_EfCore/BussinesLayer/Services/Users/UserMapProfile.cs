using AutoMapper;
using BussinesLayer.Dtos;
using Entities;

namespace BussinesLayer.Services.Users
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile() 
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<User, UserRequestDto>();
        }
    }
}
