using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.UnitOfWorks;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys;
using TCC_Backend.Infrastructure.Repository.HistoricoRepositorys;
using TCC_Backend.Infrastructure.Repository.ServicoRepositorys;

namespace TCC_Backend.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(TccBackendContext context,
                      IAvaliacaoRepository avaliacaoRepository,
                      IHistoricoRepository historicoRepository,
                      IServicoRepository servicoRepository,
                      IServicoRepositoryDependency servicoRepositoryDependency) : IUnitOfWork
    {
        private IAvaliacaoRepository? _avaliacaoRepository = avaliacaoRepository;
        private IHistoricoRepository? _historicoRepository = historicoRepository;
        private IServicoRepository? _servicoRepository = servicoRepository;

        public IAvaliacaoRepository AvaliacaoRepository => _avaliacaoRepository ??= new AvaliacaoRepository(context, servicoRepositoryDependency);

        public IHistoricoRepository HistoricoRepository => _historicoRepository ??= new HistoricoRepository(context);

        public IServicoRepository ServicoRepository => _servicoRepository ??= new ServicoRepository(context, _avaliacaoRepository!);

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
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
