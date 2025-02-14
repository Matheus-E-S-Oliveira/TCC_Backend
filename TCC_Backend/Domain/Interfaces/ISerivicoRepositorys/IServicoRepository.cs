using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;

namespace TCC_Backend.Domain.Interfaces.ISerivicoRepositorys
{
    public interface IServicoRepository
    {
        Task<List<ServicoGetAllServicosIdsAndNumeroAvalicoesDto>> GetAllServicosIdsAndNumeroAvalicoesAsync();
    }
}
