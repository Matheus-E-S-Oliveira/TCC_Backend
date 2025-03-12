using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.ServicoRepositorys
{
    public class ServicoRepositoryDependency(TccBackendContext context) : IServicoRepositoryDependency
    {
        public async Task ZerarNumeroDeAvaliacoes(Guid id)
        {
            var servico = await context.Servicos.FirstOrDefaultAsync(servico => servico.Id == id);

            if (servico != null)
            {
                servico.Update(numeroDeAvaliacoes: 0);
                await context.SaveChangesAsync();
            }
        }
    }
}
