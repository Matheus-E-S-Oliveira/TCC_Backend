using TCC_Backend.Domain.Models.Historicos;

namespace TCC_Backend.Domain.Interfaces.IHistorioRepositorys
{
    public interface IHistoricoRepository
    {
        Task<Historico?> BuscarPorDataReferenciaAsync(Guid id, DateTime dataReferencia);

        Task AdicionarAsync(Historico historico);

        Task AtualizarAsync(Historico historico);
    }
}
