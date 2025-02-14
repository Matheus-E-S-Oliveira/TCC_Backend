using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;

namespace TCC_Backend.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IAvaliacaoRepository AvaliacaoRepository { get; }

        IHistoricoRepository HistoricoRepository { get; }

        Task<int> CommitAsync();
    }
}
