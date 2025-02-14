using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys
{
    public class AvaliacaoRepository(TccBackendContext context) : IAvaliacaoRepository
    {
        public async Task<decimal> CalcularMediaCategoriaAsync(Guid id, CategoriaAvaliacao categoria, DateTime dataReferencia)
        {
            return await context.Avaliacoes
                                 .Where(a => (a.Categoria == categoria) 
                                    && (a.DataAvalicao.Month == dataReferencia.Month)
                                    && (a.DataAvalicao.Year == dataReferencia.Year)
                                    && (a.IdServico == id))
                                 .Select(a => a.Nota)
                                 .DefaultIfEmpty(0)
                                 .AverageAsync();
        }

        public async Task<List<Guid>> GetByIds()
        {
            return await context.Avaliacoes
                                    .Select(a => a.Id)
                                    .ToListAsync();
        }

        public async Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia)
        {
            var avaliacoesDoMes = context.Avaliacoes
                                          .Where(a => (a.DataAvalicao.Month == dataReferencia.Month) 
                                            && (a.DataAvalicao.Year == dataReferencia.Year)
                                            && (a.IdServico == id));

            decimal nota = 0.00m;
            foreach (var avaliacao in avaliacoesDoMes)
            {
                avaliacao.Update(nota, dataReferencia);
            }

            await context.SaveChangesAsync();
        }
    }
}
