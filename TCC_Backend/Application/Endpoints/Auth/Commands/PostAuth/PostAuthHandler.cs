using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Application.Interfaces.Servicos.IGenerateJwtTokenServices;

namespace TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth
{
    public class PostAuthHandler(TccBackendContext context, IGenerateJwtTokenService generateJwtTokenService) : BaseApiController
    {
        public async Task<IActionResult> Login([FromBody] PostAuthRequest login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest("Usuário e senha são obrigatórios.");
            }

            // Verificar usuário no banco de dados
            var user = await context.Usuarios.FirstOrDefaultAsync(u => u.Nome == login.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return Unauthorized("Credenciais inválidas");
            }

            var token = generateJwtTokenService.GenerateJwtToken(user.Nome);
            return Ok(new { Token = token });
        }
    }
}