using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Models.Avaliacoes;

namespace TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys
{
    public interface IAvaliacaoRepository
    {
        Task<decimal> CalcularMediaCategoriaAsync(Guid id, CategoriaAvaliacao categoria, DateTime dataReferencia);

        Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia);

        Task<List<Guid>> GetByIds();

        Task<decimal> CalcularMediaServicoAsync(Guid id, CategoriaAvaliacao categoria);

        Task<List<Avaliacao>> GetAvalicaoServicoById(Guid id);

        Task<object> UpdateAvalicaoService(List<Avaliacao> avalicaoService, Dictionary<int, int> Respostas);
    }
}
