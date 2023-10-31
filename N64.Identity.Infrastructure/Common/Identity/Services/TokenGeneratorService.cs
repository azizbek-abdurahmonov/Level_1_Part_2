using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N64.Identity.Application.Common.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using N64.Identity.Domain.Entity;
using N64.Identity.Application.Common.Constants;
using N64.Identity.Application.Common.Identity.Services;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
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
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes));
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimTypes.Email, user.EmailAddress),
        };
    }

}
