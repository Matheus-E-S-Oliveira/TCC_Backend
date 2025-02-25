using Microsoft.AspNetCore.Mvc;

namespace TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico
{
    public class GetAvaliacaoPorServicoRequest
    {
        [FromRoute]
        public Guid Id { get; set; }

    }
}
