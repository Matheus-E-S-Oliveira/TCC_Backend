using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuth;
using TCC_Backend.Application.Endpoints.Auth.Commands.PostAuthAdm;
using TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao;
using TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;

namespace TCC_Backend.Application.Endpoints.Auth
{
    public class AuthController : BaseController
    {
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
        public async Task<IActionResult> Post([FromBody] PostAuthRequest request)
        {
            return await Post<PostAuthRequest, PostAuthHandler>(request);
        }

        [HttpPost("adm")]
        public async Task<IActionResult> PostAdm([FromBody] PostAuthAdmRequest request)
        {
            return await Post<PostAuthAdmRequest, PostAuthAdmHandler>(request);
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
