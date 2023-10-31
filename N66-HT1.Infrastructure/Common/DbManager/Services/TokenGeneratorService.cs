using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N66_HT1.Application.Common.Constants;
using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Application.Common.Settings;
using N66_HT1.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N66_HT1.Infrastructure.Common.DbManager.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
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
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes));
    }

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    private List<Claim> GetClaims(User user)
    {
        return new()
        {
           new(ClaimTypes.Email, user.Email),
           new(ClaimConstants.UserId, user.Id.ToString())
        };
    }
}
