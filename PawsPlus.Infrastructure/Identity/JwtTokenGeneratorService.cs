using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PawsPlus.Application.Common;

namespace PawsPlus.Infrastructure.Identity;

public class JwtTokenGeneratorService(IOptions<ApplicationSettings> applicationSettings)
    : IJwtTokenGenerator
{
    private readonly ApplicationSettings _applicationSettings = applicationSettings.Value;
    
    public string GenerateToken(string userId, string userName, IList<string> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_applicationSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
                
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        foreach (var userRole in roles)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userRole));
        }
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }
}