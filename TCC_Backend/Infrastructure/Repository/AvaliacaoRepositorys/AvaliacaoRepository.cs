using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.TokenValidationDtos;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.Models.Avaliacoes;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Service.TokenServices;

namespace TCC_Backend.Infrastructure.Repository.AvaliacaoRepositorys
{
    public class AvaliacaoRepository(TccBackendContext context, IServicoRepositoryDependency servicoRepository) : IAvaliacaoRepository
    {
        public async Task<decimal> CalcularMediaCategoriaAsync(Guid id, CategoriaAvaliacao categoria, DateTime dataReferencia)
        {
            var avaliacoes = await context.Avaliacoes
                                 .Where(a => (a.Categoria == categoria)
                                    && (a.DataAvalicao.Month == dataReferencia.Month)
                                    && (a.DataAvalicao.Year == dataReferencia.Year)
                                    && (a.IdServico == id))
                                 .ToListAsync();

            var filtradas = avaliacoes
                            .Where(a => a.Categoria == categoria)
                            .Select(a => a.Nota)
                            .DefaultIfEmpty(0);

            return filtradas.Average();
        }

        public async Task<decimal> CalcularMediaServicoAsync(Guid id, CategoriaAvaliacao categoria)
        {
            var avaliacoes = await context.Avaliacoes
                                   .Where(a => a.IdServico == id)
                                   .ToListAsync();

            var filtradas = avaliacoes
                            .Where(a => a.Categoria == categoria)
                            .Select(a => a.Nota)
                            .DefaultIfEmpty(0);

            return filtradas.Average();
        }

        public async Task<List<Avaliacao>> GetAvalicaoServicoById(Guid id)
        {
            return await context.Avaliacoes
                            .Where(service => service.IdServico == id)
                            .ToListAsync();
        }

        public async Task<List<Guid>> GetByIds()
        {
            return await context.Avaliacoes
                                    .Select(a => a.Id)
                                    .ToListAsync();
        }

        public async Task<TokenValidationDto> CheckAuth(string token, Guid idServico)
        {
            var type = TokenService.ObterDadosDoToken(token);

            if (string.IsNullOrWhiteSpace(type.Sub) || string.IsNullOrWhiteSpace(type.Type))
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Token inválido. Por favor, faça login novamente."
                };
            }

            if (!Guid.TryParse(type.Sub, out Guid subGuid))
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Token inválido. Dados corrompidos. Por favor, faça login novamente."
                };
            }

            if (type.Type != "user")
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Apenas usuários podem avaliar o serviço."
                };
            }

            if (await CheckUltimaAvalicaoPorServico(idServico, subGuid) == false)
            {
                return new TokenValidationDto
                {
                    IsTokenValid = false,
                    Menssage = "Você já avaliou este serviço neste mês. Não é possível avaliar novamente. Tente no próximo mês."
                };
            }

            return new TokenValidationDto
            {
                IsTokenValid = await context.Usuarios.AnyAsync(x => x.Id == subGuid && x.Type == type.Type),
                Menssage = "Você não tem permissão para avaliar.",
                Id = subGuid
            };
        }

        private async Task<bool> CheckUltimaAvalicaoPorServico(Guid idServico, Guid idUser)
        {
            var result = await context.UsuarioServicoAvaliacoes
                .Where(x => x.UsuarioId == idUser && x.ServicoId == idServico)
                .Select(x => x.DataUltimaAvaliacao)
                .FirstOrDefaultAsync();

            if (result.Month == DateTime.UtcNow.Month && result.Year == DateTime.UtcNow.Year)
                return false;

            return true;
        }

        public async Task<object> UpdateAvalicaoService(List<Avaliacao> avalicaoService, Dictionary<int, int> Respostas)
        {
            bool hasChanges = false;

            foreach (var avaliacao in avalicaoService)
            {
                if (Respostas.TryGetValue((int)avaliacao.Categoria, out int nota))
                {
                    var notaAcumulada = avaliacao.Nota + nota;
                    avaliacao.Update(
                        nota: notaAcumulada,
                        dataAvalicao: DateTime.UtcNow
                    );

                    hasChanges = true;
                }

            }
            if (!hasChanges)
                return "Nenhuma alteração foi feita.";

            int saved = await context.SaveChangesAsync();

            return saved;
        }

        public async Task ZerarAvaliacoesAsync(Guid id, DateTime dataReferencia)
        {
            var avaliacoesDoMes = context.Avaliacoes
                                          .Where(a => (a.DataAvalicao.Month == dataReferencia.Month)
                                            && (a.DataAvalicao.Year == dataReferencia.Year)
                                            && (a.IdServico == id));

            decimal nota = 0.00m;
            foreach (var avaliacao in avaliacoesDoMes)
            {
                avaliacao.Update(nota, dataReferencia);
            }

            await servicoRepository.ZerarNumeroDeAvaliacoes(id);

            await context.SaveChangesAsync();
        }

        public async Task<int> CreateAvaliacaoByServico(Guid idServico)
        {
            decimal nota = 0.0m;

            var avaliacoes = Enum.GetValues<CategoriaAvaliacao>()
                                 .Cast<CategoriaAvaliacao>()
                                 .Select(categoria => new Avaliacao(idServico, categoria, nota))
                                 .ToList();

            await context.Avaliacoes.AddRangeAsync(avaliacoes);

            return await context.SaveChangesAsync();
        }
    }
}
