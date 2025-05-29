using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Application.Dtos.ServicoDtos.ServicoAvalicaoDtos;

namespace TCC_Backend.Application.Endpoints.Servico.Queries.GetServicos
{
    public class GetServicosHandler(TccBackendContext context, IServicoRepository servicoRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(GetServicosRequest request)
        {
            if (request == null)
            {
            }

            var result = await context.Servicos
                .Select(x => new ServicoAvaliacaoDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Titulo = x.Titulo,
                    NumeroDeAvaliacoes = x.NumeroDeAvaliacoes,
                    Localizacao = x.Localizacao,
                    Imagem = x.Imagem,
                    UrlSite = x.UrlSite ?? string.Empty
                })
                .ToListAsync();

            if (result.Count == 0)
            {
                return Error(["Serviço não encontrado"]);
            }

            foreach (var servico in result)
            {
                servico.Media = await servicoRepository.CalcularMediaServicoAsync(servico.Id);
            }

            return Success(result);
        }
    }
}
