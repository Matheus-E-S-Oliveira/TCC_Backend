using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.HistoricoRepositorys
{
    public class HistoricoRepository(TccBackendContext context) : IHistoricoRepository
    {
        public async Task AdicionarAsync(Historico historico)
        {
            await context.Historicos.AddAsync(historico);
        }

        public async Task AtualizarAsync(Historico historico)
        {
            context.Historicos.Update(historico);
            await context.SaveChangesAsync();
        }

        public async Task<Historico?> BuscarPorDataReferenciaAsync(Guid id, DateTime dataReferencia)
        {
            return await context.Historicos
                                .FirstOrDefaultAsync(h => (h.DataReferencia.HasValue)
                                && (h.DataReferencia.Value.Month == dataReferencia.Month) 
                                && (h.DataReferencia.Value.Year == dataReferencia.Year)
                                && (h.IdServico == id));
        }
    }
}
