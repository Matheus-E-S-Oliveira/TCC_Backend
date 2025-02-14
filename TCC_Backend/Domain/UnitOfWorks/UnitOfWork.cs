using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys;
using TCC_Backend.Infrastructure.Repository.HistoricoRepositorys;
using TCC_Backend.Infrastructure.UnitOfWorks;

namespace TCC_Backend.Domain.UnitOfWorks
{
    public class UnitOfWork(TccBackendContext context) : IUnitOfWork
    {

        private IAvaliacaoRepository? _avaliacaoRepository;
        private IHistoricoRepository? _historicoRepository;

        public IAvaliacaoRepository AvaliacaoRepository => _avaliacaoRepository ??= new AvaliacaoRepository(context);

        public IHistoricoRepository HistoricoRepository => _historicoRepository ??= new HistoricoRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
