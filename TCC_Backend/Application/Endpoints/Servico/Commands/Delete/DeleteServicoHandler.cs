using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Servico.Commands.Delete
{
    public class DeleteServicoHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Handle(Guid id)
        {
            var result = await context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return Error(["Serviço não encontrado"]);
            }

            context.Servicos.Remove(result);
            await context.SaveChangesAsync();

            return OkResponse(["Serviço excluido com sucesso"], StatusCodes.Status200OK);
        }
    }
}
