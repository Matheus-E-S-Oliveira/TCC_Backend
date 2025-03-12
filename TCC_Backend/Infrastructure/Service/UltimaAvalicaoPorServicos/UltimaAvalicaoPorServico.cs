using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Interfaces.IUltimaAvalicaoPorServicos;

namespace TCC_Backend.Infrastructure.Service.UltimaAvalicaoPorServicos
{
    public class UltimaAvalicaoPorServico(TccBackendContext context) : IUltimaAvalicaoPorServico
    {
        public async Task<Dictionary<Guid, DateTime?>> GetUltimaAvaliacaiServicoFromUser(Guid userId)
        {
            var result = await context.Servicos
                 .Select(s => new
                 {
                     ServicoId = s.Id,
                     DataUltimaAvaliacao = context.UsuarioServicoAvaliacoes
                         .Where(usa => usa.UsuarioId == userId && usa.ServicoId == s.Id)
                         .Select(usa => usa.DataUltimaAvaliacao)
                         .FirstOrDefault()
                 })
                 .ToListAsync();

            return result.ToDictionary(x => x.ServicoId, x => (DateTime?)x.DataUltimaAvaliacao);
        }
    }
}
