using Microsoft.IdentityModel.Tokens;
using N63_Task2.Models.Dtos;
using N63_Task2.Models.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N63_Task2.Services;

public class TokenGeneratorService
{
    private readonly string _key = "DF6-JHJS8-IJIA8-H7FHFA5-O0";

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;
    }


    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: "MyServerApp",
            audience: "MyClientApp",
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);
    }

    private List<Claim> GetClaims(User user)
    {
        return new List<Claim>
        {
            new (ClaimConstants.UserId, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email)
        };
    }
}
