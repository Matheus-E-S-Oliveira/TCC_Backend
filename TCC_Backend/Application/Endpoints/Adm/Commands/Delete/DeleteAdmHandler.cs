using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Endpoints.Adm.Commands.Delete
{
    public class DeleteAdmHandler(TccBackendContext context) : BaseApiController
    {
        public async Task<IActionResult> Hanlde(Guid id)
        {
            var result = await context.Adms.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null) return Error(["Adiminstrador não foi encontrado"], StatusCodes.Status404NotFound);

            context.Adms.Remove(result);
            await context.SaveChangesAsync();

            return OkResponse(["Administrador excluido com sucesso"], StatusCodes.Status200OK);
        }
    }
}
