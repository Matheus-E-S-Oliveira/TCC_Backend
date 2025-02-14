using TCC_Backend.Application.Dtos.MediasDtos;
using TCC_Backend.Application.Interfaces.IHistoricoService;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.IHistorioRepositorys;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Infrastructure.UnitOfWorks;

namespace TCC_Backend.Application.Services.HistoricoServices
{
    public class HistoricoService(
        IAvaliacaoRepository avaliacaoRepository,
        IHistoricoRepository historicoRepository,
        IUnitOfWork unitOfWork) : IHistoricoService
    {
        public async Task AtualizarHistoricoAsync(MediasDtos medias, DateTime dataReferencia, Guid idServico, int numeroDeAvaliacoes)
        {
            var historicoExistente = await historicoRepository.BuscarPorDataReferenciaAsync(idServico, dataReferencia);

            if (historicoExistente == null)
            {
                var novoHistorico = new Historico(
                    idServico,
                    medias.Categoria1,
                    medias.Categoria2,
                    medias.Categoria3,
                    medias.Categoria4,
                    medias.Categoria5,
                    numeroDeAvaliacoes,
                    dataReferencia
                );

                await historicoRepository.AdicionarAsync(novoHistorico);
            }
            else
            {
                historicoExistente.Update(
                    medias.Categoria1,
                    medias.Categoria2,
                    medias.Categoria3,
                    medias.Categoria4,
                    medias.Categoria5,
                    numeroDeAvaliacoes,
                    dataReferencia
                );

                await historicoRepository.AtualizarAsync(historicoExistente);
            }
        }

        public async Task AtualizarHistoricoEZerarAvaliacoesAsync(DateTime dataReferencia, Guid idServico, int numeroDeAvaliacoes)
        {
            var medias = await CalcularMediasAvaliacoesAsync(idServico, dataReferencia);

            await AtualizarHistoricoAsync(medias, dataReferencia, idServico, numeroDeAvaliacoes);

            await ZerarAvaliacoesAsync(idServico, dataReferencia);

            await unitOfWork.CommitAsync();
        }

        public async Task<MediasDtos> CalcularMediasAvaliacoesAsync(Guid id, DateTime dataReferencia)
        {
            return new MediasDtos
            {
                Categoria1 = await avaliacaoRepository.CalcularMediaCategoriaAsync(id, CategoriaAvaliacao.ExperienciaGeral, dataReferencia),
                Categoria2 = await avaliacaoRepository.CalcularMediaCategoriaAsync(id, CategoriaAvaliacao.Infraestrutura, dataReferencia),
                Categoria3 = await avaliacaoRepository.CalcularMediaCategoriaAsync(id, CategoriaAvaliacao.ClarezaInformacoes, dataReferencia),
                Categoria4 = await avaliacaoRepository.CalcularMediaCategoriaAsync(id, CategoriaAvaliacao.TempoEspera, dataReferencia),
                Categoria5 = await avaliacaoRepository.CalcularMediaCategoriaAsync(id, CategoriaAvaliacao.QualidadeAtendimento, dataReferencia)
            };
        }

        public async Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia)
        {
            await avaliacaoRepository.ZerarAvaliacoesAsync(id, dataReferencia);
        }
    }
}
