using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.ServicoRepositorys
{
    public class ServicoRepository(TccBackendContext context, IAvaliacaoRepository avaliacaoRepository) : IServicoRepository
    {
        public async Task<List<ServicoGetAllServicosIdsAndNumeroAvalicoesDto>> GetAllServicosIdsAndNumeroAvalicoesAsync()
        {
            return await context.Servicos
                            .Select(x => new ServicoGetAllServicosIdsAndNumeroAvalicoesDto
                            {
                                Id = x.Id,
                                NumeroDeAvalicoes = x.NumeroDeAvalicoes
                            })
                            .ToListAsync();
        }

        public async Task<decimal> CalcularMediaServicoAsync(Guid id)
        {
            var categorias = Enum.GetValues<CategoriaAvaliacao>();

            var medias = new List<decimal>();

            foreach (var categoria in categorias)
            {
                var mediaCategoria = await avaliacaoRepository.CalcularMediaServicoAsync(id, categoria);
                medias.Add(mediaCategoria);
            }

            return medias.Count > 0 ? medias.Average() : 0;
        }

        public async Task AtualizarNumeroAvaliacoes(Guid id)
        {
            var servico = context.Servicos
                    .FirstOrDefault(x => x.Id == id);

            if (servico != null)
            {
                servico.Update(numeroDeAvaliacoes: servico.NumeroDeAvalicoes + 1);
                await context.SaveChangesAsync();
            }
        }

        public async Task ZerarNumeroDeAvaliacoes(Guid id)
        {
            var servico = await context.Servicos.FirstOrDefaultAsync(servico => servico.Id == id);

            if (servico != null)
            {
                servico.Update(numeroDeAvaliacoes: 0);
                await context.SaveChangesAsync();
            }
        }
    }
}
