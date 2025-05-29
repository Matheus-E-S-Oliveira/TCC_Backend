using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;
using TCC_Backend.Application.Endpoints.Usuario.Commands.Post.RegisterUsuario;

namespace TCC_Backend.Application.Endpoints.Usuario
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsuarioController() : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUsuarioRequest request)
        {
            return await Post<RegisterUsuarioRequest, RegisterUsuarioHandler>(request);
        }
    }
}
