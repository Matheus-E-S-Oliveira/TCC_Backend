using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TCC_Backend.Application.Dtos.TokenDataDtos;

namespace TCC_Backend.Infrastructure.Service.TokenServices
{
    public class TokenService
    {
        private const string SecretKey = "1aLklf9LAF0YLhKRtS72F7S2CoMiVGuUtoabPyt8RwKwwojEr7";

        public static bool ValidarToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // Defina como `true` se quiser verificar o emissor
                    ValidateAudience = false, // Defina como `true` se quiser verificar a audiência
                    ValidateLifetime = true, // Verifica se o token expirou
                    ClockSkew = TimeSpan.Zero // Remove tempo extra de tolerância
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static TokenDataDto ObterDadosDoToken(string token)
        {
            if (!ValidarToken(token))
            {
                return new TokenDataDto { Sub = null, Type = null };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var payload = jwtToken.Payload;
  
            return new TokenDataDto
            {
                Sub = payload.TryGetValue("sub", out var sub) ? sub?.ToString() : null,
                Type = payload.TryGetValue("type", out var type) ? type?.ToString() : null
            };
        }
    }
}
