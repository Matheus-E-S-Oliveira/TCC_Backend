using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Dtos.TokenDtos;
using TCC_Backend.Domain.Interfaces.IUsuarioRepositorys;
using TCC_Backend.Infrastructure.Security.Tokens.Access;

namespace TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario
{
    public class RegisterUsuarioHandler(IUsuarioRepository usuarioRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(RegisterUsuarioRequest request)
        {
            var result =  await usuarioRepository.RegisterUsuario(request);

            if (result.Sussecs > 0)
                return Created("Usuario salvo com sucesso", result.AccessToken, StatusCodes.Status201Created);

            return Error("Erro ao registrar o usuario", StatusCodes.Status400BadRequest);
        }    
    }
}
