using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Pergunta.Queries.GetPerguntasByServico
{
    public class GetPerguntasByServicoHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetPerguntasByServicoRequest request)
        {
            var result = await context.Perguntas
                    .Where(x => x.IdServico == request.Id)
                    .ToListAsync();

            if (result == null)
            {
                return Error(["Serviço não tem perguntas cadastradas"]);
            }

            return Success(result);
        }
    }
}
