using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Servico.Queries.GetServicoPorId
{
    public class GetServicoPorIdHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetServicoPorIdRequest request)
        {
            var result = await context.Servicos.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null)
            {
                return Error(["Serviço não encontrado"]);
            }

            return Success(result);
        }
    }
}
