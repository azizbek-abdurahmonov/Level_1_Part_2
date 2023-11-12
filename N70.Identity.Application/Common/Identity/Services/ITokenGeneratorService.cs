using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface ITokenGeneratorService
{
    List<Claim> GetClaims(User user);

    string GetToken(User user);

    JwtSecurityToken GetJwtToken(User user);
}