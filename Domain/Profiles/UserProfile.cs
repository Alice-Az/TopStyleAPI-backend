using AutoMapper;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.Domain.Models.User;

namespace TopStyleAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<User, LoginResponse>();
        }
    }
}
