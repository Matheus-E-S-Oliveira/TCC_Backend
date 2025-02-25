using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao;
using TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;

namespace TCC_Backend.Application.Endpoints.Avalicacao
{
    public class AvaliacaoController : BaseController
    {
        //[HttpGet("avaliacao")] caso queria implementar alem da rota basica
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetServicosRequest request)
        {
            return await Get<GetServicosRequest, GetServicosHandler>(request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await GetById<GetAvaliacaoPorServicoRequest, GetAvaliacaoPorServicoHandler>(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GetServicosRequest request)
        {
            return await Post<GetServicosRequest, GetServicosHandler>(request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutAvaliacaoRequest request)
        {
            return await Put<PutAvaliacaoRequest, PutAvaliacaoHandler>(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete<GetServicosRequest, GetServicosHandler>(id);
        }
    }
}
