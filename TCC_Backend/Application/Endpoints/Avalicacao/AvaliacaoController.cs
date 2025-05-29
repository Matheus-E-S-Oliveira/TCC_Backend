using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao;
using TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico;
using TCC_Backend.Application.Responses.PutResponses;

namespace TCC_Backend.Application.Endpoints.Avalicacao
{
    public class AvaliacaoController : BaseController
    {
        //[HttpGet("avaliacao")] caso queria implementar alem da rota basica

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await GetById<GetAvaliacaoPorServicoRequest, GetAvaliacaoPorServicoHandler>(id);
        }

        [ProducesResponseType(typeof(ResponsePutJson), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutAvaliacaoRequest request)
        {
            return await Put<PutAvaliacaoRequest, PutAvaliacaoHandler>(id, request);
        }
    }
}
