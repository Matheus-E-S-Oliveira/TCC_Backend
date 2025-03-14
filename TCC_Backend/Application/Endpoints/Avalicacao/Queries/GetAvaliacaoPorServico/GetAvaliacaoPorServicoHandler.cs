using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Avalicacao.Queries.GetAvaliacaoPorServico
{
    public class GetAvaliacaoPorServicoHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetAvaliacaoPorServicoRequest request)
        {
            var result = await context.Avaliacoes
                .Where(x => x.IdServico == request.Id)
                .ToListAsync();

            if (result == null || result.Count == 0)
            {
                return Error(["Não foram encontradas avaliações para este serviço"]);
            }

            return Success(result);
        }
    }
}
