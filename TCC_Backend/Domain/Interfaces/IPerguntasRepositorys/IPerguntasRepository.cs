using TCC_Backend.Application.Dtos.PerguntasDtos;

namespace TCC_Backend.Domain.Interfaces.IPerguntasRepositorys
{
    public interface IPerguntasRepository
    {
        Task <int> SavePergunta(Guid idServico, List<PerguntaDto> perguntas);

        Task<int> UpdatePergunta(Guid idServico, List<PerguntaDto> perguntas);
    }
}
