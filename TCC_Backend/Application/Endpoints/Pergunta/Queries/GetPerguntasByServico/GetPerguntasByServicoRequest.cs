using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Pergunta.Queries.GetPerguntasByServico
{
    public class GetPerguntasByServicoRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
