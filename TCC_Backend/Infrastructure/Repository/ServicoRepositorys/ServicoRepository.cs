using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.ServicoDtos.ServicoGetAllServicosIdsAndNumeroAvalicoesDtos;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.ServicoRepositorys
{
    public class ServicoRepository(TccBackendContext context) : IServicoRepository
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
    }
}
