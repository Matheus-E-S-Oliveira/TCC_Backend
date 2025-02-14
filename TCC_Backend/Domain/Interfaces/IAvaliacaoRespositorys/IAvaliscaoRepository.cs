using TCC_Backend.Domain.Enums;

namespace TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys
{
    public interface IAvaliacaoRepository
    {
        Task<decimal> CalcularMediaCategoriaAsync(Guid id, CategoriaAvaliacao categoria, DateTime dataReferencia);

        Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia);

        Task<List<Guid>> GetByIds();
    }
}
