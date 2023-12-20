using AutoMapper;
using N90_HT1.Application.Common.Identity.Models;
using N90_HT1.Domain.Entities;

namespace N90_HT1.Infrastructure.Common.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<SignUpDetails, User>();
    }
}