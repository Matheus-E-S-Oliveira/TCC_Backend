using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Servico.Commands.Delete;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;

namespace TCC_Backend.Application.Endpoints.Servico
{
    public class ServicoController() : BaseController
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
        public async Task<IActionResult> Post([FromBody] PostServicoRequest request)
        {
            return await Post<PostServicoRequest, PostServicoHandler>(request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutServicoRequest request)
        {
            return await Put<PutServicoRequest, PutServicoHandler>(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete<DeleteServicoRequest, DeleteServicoHandler>(id);
        }
    }


}
