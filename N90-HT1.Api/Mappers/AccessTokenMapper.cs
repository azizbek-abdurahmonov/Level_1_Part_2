using AutoMapper;
using N90_HT1.Api.Models.Dtos;
using N90_HT1.Domain.Entities;

namespace N90_HT1.Api.Mappers;

public class AccessTokenMapper : Profile
{
    public AccessTokenMapper()
    {
        CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
    }
}