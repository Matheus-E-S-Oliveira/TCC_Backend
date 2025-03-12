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
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetServicosRequest request)
        {
            return await Get<GetServicosRequest, GetServicosHandler>(request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await GetById<GetServicoPorIdRequest, GetServicoPorIdHandler>(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUsuarioRequest request)
        {
            return await Post<RegisterUsuarioRequest, RegisterUsuarioHandler>(request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GetServicosRequest request)
        {
            return await Put<GetServicosRequest, GetServicosHandler>(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete<GetServicosRequest, GetServicosHandler>(id);
        }
    }
}
