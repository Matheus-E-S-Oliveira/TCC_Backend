using Microsoft.AspNetCore.Mvc;
using TCC_Backend.Application.Endpoints.Pergunta.Queries.GetPerguntasByServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;
using TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos;

namespace TCC_Backend.Application.Endpoints.Pergunta
{
    public class PerguntaController : BaseController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await GetById<GetPerguntasByServicoRequest, GetPerguntasByServicoHandler>(id);
        }
    }


}
