using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TCC_Backend.Domain.Models.Adms;
using TCC_Backend.Domain.Models.Usuarios;
using TCC_Backend.Infrastructure.Interfaces.IUltimaAvalicaoPorServicos;

namespace TCC_Backend.Infrastructure.Security.Tokens.Access
{
    public class JwtTokenGenerator(IUltimaAvalicaoPorServico ultimaAvalicaoPorServico)
    {
        public async Task<string> Generate(Usuario user)
        {
            var servico = await ultimaAvalicaoPorServico.GetUltimaAvaliacaiServicoFromUser(user.Id);

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, user.Nome),
                new("type", user.Type),
                new("servicos_avaliados", JsonSerializer.Serialize(servico))
            };

            var tokernDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securytToken = tokenHandler.CreateToken(tokernDescriptor);

            return tokenHandler.WriteToken(securytToken);
        }

        private static SymmetricSecurityKey SecurityKey()
        {
            var signinKey = "1aLklf9LAF0YLhKRtS72F7S2CoMiVGuUtoabPyt8RwKwwojEr7";

            var symmetricKey = Encoding.UTF8.GetBytes(signinKey);

            return new SymmetricSecurityKey(symmetricKey);
        }

        public static string GenerateTokenAdm(Adm adm)
        {
            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, adm.Id.ToString()),
                new(JwtRegisteredClaimNames.Name, adm.UserName),
                new("type", adm.Type),
            };

            var tokernDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securytToken = tokenHandler.CreateToken(tokernDescriptor);

            return tokenHandler.WriteToken(securytToken);
        }
    }
}
