using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N70.Identity.Application.Common.Constants;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Settings;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value!;
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimTypes.Role, user.Role.Type.ToString())
        };
    }

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinutes));
    }
}