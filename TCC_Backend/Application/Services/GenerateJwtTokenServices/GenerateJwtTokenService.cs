using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCC_Backend.Application.Interfaces.Servicos.IGenerateJwtTokenServices;

namespace TCC_Backend.Application.Services.GenerateJwtTokenServices
{
    public class GenerateJwtTokenService(IConfiguration configuration) : IGenerateJwtTokenService
    {
        public string GenerateJwtToken(string username)
        {
            var jwtSettings = configuration.GetSection("Jwt");

            if (!double.TryParse(jwtSettings["ExpireInMinutes"], out double expireMinutes))
            {
                expireMinutes = 60;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
