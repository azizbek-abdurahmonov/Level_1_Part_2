using AutoMapper;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
    }
}