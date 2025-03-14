using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IAuthRepositorys;

namespace TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm
{
    //senha master 7heEuS85AvQ8
    public class PostAuthAdmHandler(IAuthRepository authRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(PostAuthAdmRequest request)
        {
            var validate = authRepository.Validar(request);

            if (validate.Result.Count > 0)
                return Error(validate.Result, StatusCodes.Status400BadRequest);

            var result = await authRepository.LoginAdm(request);

            if (result.Sussecs > 0)
                return Created(["Login realizado com sucesso"], result.AccessToken, StatusCodes.Status200OK);

            return BadRequest(["E-mail/Nome de usuário ou senha inválidos."], StatusCodes.Status401Unauthorized);
        }
    }
}
