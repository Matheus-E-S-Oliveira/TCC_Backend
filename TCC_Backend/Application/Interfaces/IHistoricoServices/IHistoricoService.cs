using TCC_Backend.Application.Dtos.MediasDtos;

namespace TCC_Backend.Application.Interfaces.IHistoricoService
{
    public interface IHistoricoService
    {
        Task AtualizarHistoricoEZerarAvaliacoesAsync(DateTime dataReferencia, Guid id, int numeroAvaliacoes);

        Task<MediasDtos> CalcularMediasAvaliacoesAsync(Guid id, DateTime dataReferencia);

        Task AtualizarHistoricoAsync(MediasDtos medias, DateTime dataReferencia, Guid idServico, int numeroDeAvaliacoes);

        Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia);
    }
}
