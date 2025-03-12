using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IAuthRepositorys;

namespace TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth
{
    public class PostAuthHandler(IAuthRepository authRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostAuthRequest request)
        {
            var result = await authRepository.Login(request);

            if (result.Sussecs > 0)
                return Created("Login realizado com sucesso", result.AccessToken, StatusCodes.Status200OK);

            return BadRequest("E-mail/Nome de usuário ou senha inválidos.", StatusCodes.Status401Unauthorized);
        }
    }
}