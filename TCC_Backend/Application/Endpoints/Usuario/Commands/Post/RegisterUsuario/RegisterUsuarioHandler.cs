using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Domain.Interfaces.IUsuarioRepositorys;

namespace TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario
{
    public class RegisterUsuarioHandler(IUsuarioRepository usuarioRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(RegisterUsuarioRequest request)
        {
            var validate = await usuarioRepository.Validar(request);

            if (validate.Count > 0)
                return Error(validate, StatusCodes.Status400BadRequest);

            var result =  await usuarioRepository.RegisterUsuario(request);

            if (result.Sussecs > 0)
                return Created(["Usuario salvo com sucesso"], result.AccessToken, StatusCodes.Status201Created);

            return Error(["Erro ao registrar o usuario"], StatusCodes.Status400BadRequest);
        }    
    }
}
