using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;
using TCC_Backend.Domain.Enums;

namespace TCC_Backend.Domain.Interfaces.ISerivicoRepositorys
{
    public interface IServicoRepository
    {
        Task<List<ServicoGetAllServicosIdsAndNumeroAvalicoesDto>> GetAllServicosIdsAndNumeroAvalicoesAsync();

        Task<decimal> CalcularMediaServicoAsync(Guid id);

        Task AtualizarNumeroAvaliacoes(Guid id);

        Task ZerarNumeroDeAvaliacoes(Guid id);
    }
}
