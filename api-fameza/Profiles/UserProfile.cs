using api_fameza.Dtos;
using api_fameza.Models;
using AutoMapper;

namespace api_fameza.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role,opt=>opt.MapFrom(src => src.Role!.Name));
        }
    }
}
