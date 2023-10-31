using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N63_HT1.Models.Constants;
using N63_HT1.Models.Entities;
using N63_HT1.Models.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N63_HT1.Services;

public class TokenGeneratorService
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
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            signingCredentials: credentials,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes));
    }

    private List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new(ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        };
    }
}
