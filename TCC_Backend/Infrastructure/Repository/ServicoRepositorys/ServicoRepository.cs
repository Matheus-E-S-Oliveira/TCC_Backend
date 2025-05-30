using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;
using TCC_Backend.Application.Endpoints.Servico.Commands.Post.PostServico;
using TCC_Backend.Application.Endpoints.Servico.Commands.Put.PutServico;
using TCC_Backend.Domain.Enums;
using TCC_Backend.Domain.Interfaces.IAvaliacaoRespositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Domain.Models.Servicos;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Validators.Servico.Post;
using TCC_Backend.Infrastructure.Validators.Servico.Put;

namespace TCC_Backend.Infrastructure.Repository.ServicoRepositorys
{
    public class ServicoRepository(TccBackendContext context,
                                   IAvaliacaoRepository avaliacaoRepository,
                                   ServicoValidator validations,
                                   ServicoPutValidator rules) : IServicoRepository
    {
        public async Task<List<ServicoGetAllServicosIdsAndNumeroAvalicoesDto>> GetAllServicosIdsAndNumeroAvalicoesAsync()
        {
            return await context.Servicos
                            .Select(x => new ServicoGetAllServicosIdsAndNumeroAvalicoesDto
                            {
                                Id = x.Id,
                                NumeroDeAvalicoes = x.NumeroDeAvaliacoes
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
                servico.Update(numeroDeAvaliacoes: servico.NumeroDeAvaliacoes + 1);
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

        public Task<List<string>> Validar(PostServicoRequest request)
        {
            var validate = validations.Validate(request);

            return Task.FromResult(validate.Errors.Select(erro => erro.ErrorMessage).ToList());
        }

        public async Task<Guid?> SaveServico(PostServicoRequest request)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var service = new Servico(
                    nome: request.Nome,
                    titulo: request.Titulo,
                    numeroDeAvalicoes: 0,
                    localizacao: request.Localizacao,
                    imagem: request.Imagem,
                    site: request.UrlSite);

                await context.AddAsync(service);
                var result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    var createAvaliacao = await avaliacaoRepository.CreateAvaliacaoByServico(service.Id);

                    if (createAvaliacao > 0)
                    {
                        await transaction.CommitAsync();
                        return service.Id;
                    }
                }

                await transaction.RollbackAsync();
                return null;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public Task<List<string>> Validar(PutServicoRequest request)
        {
            var validate = rules.Validate(request);

            return Task.FromResult(validate.Errors.Select(erro => erro.ErrorMessage).ToList());
        }

        public async Task<int> UpdateServico(Guid id, PutServicoRequest request)
        {
            var servico = await GetServicoById(id);

            if (servico == null)
                return 0;

            servico.Update(
                nome: request.Nome,
                titulo: request.Titulo,
                localizacao: request.Localizacao,
                imagem: request.Imagem,
                site: request.UrlSite);

            try
            {
                await context.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        private async Task<Servico?> GetServicoById(Guid id)
        {
            var result = await context.Servicos
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

            return result;
        }
    }
}
