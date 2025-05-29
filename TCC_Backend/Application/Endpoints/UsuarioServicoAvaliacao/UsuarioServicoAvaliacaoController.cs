using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.UsuarioServicoAvaliacao.Queries;

namespace TCC_Backend.Application.Endpoints.UsuarioServicoAvaliacao
{
    public class UsuarioServicoAvaliacaoController() : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await GetById<UsuarioServicoAvaliacaoRequest, UsuarioServicoAvaliacaoHandler>(id);
        }
    }
}
