using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;

namespace TCC_Backend.Domain.Interfaces.ISerivicoRepositorys
{
    public interface IServicoRepository
    {
        Task<List<ServicoGetAllServicosIdsAndNumeroAvalicoesDto>> GetAllServicosIdsAndNumeroAvalicoesAsync();

        Task<decimal> CalcularMediaServicoAsync(Guid id);

        Task AtualizarNumeroAvaliacoes(Guid id);

        Task ZerarNumeroDeAvaliacoes(Guid id);

        Task<List<string>> Validar(PostServicoRequest request);

        Task<List<string>> Validar(PutServicoRequest request);

        Task <Guid?> SaveServico(PostServicoRequest request);

        Task<int> UpdateServico(Guid id, PutServicoRequest request);
    }
}
