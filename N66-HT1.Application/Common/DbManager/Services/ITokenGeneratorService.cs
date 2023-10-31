using N66_HT1.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace N66_HT1.Application.Common.DbManager.Services;

public interface ITokenGeneratorService
{
    JwtSecurityToken GetJwtToken(User user);

    string GetToken(User user);
}
