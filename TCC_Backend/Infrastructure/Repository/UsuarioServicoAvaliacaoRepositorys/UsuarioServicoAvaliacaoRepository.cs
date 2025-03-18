using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Infrastructure.Interfaces.IUltimaAvalicaoPorServicos;
using TCC_Backend.Infrastructure.Service.TokenServices;

namespace TCC_Backend.Infrastructure.Repository.UsuarioServicoAvaliacaoRepositorys
{
    public class UsuarioServicoAvaliacaoRepository(TccBackendContext context, IUltimaAvalicaoPorServico ultimaAvalicaoPorServico) : IUsuarioServicoAvaliacaoRepository
    {
        private async Task SalvarDataUltimaAvaliacaoPorServico(Guid idUser, Guid idService)
        {
            var ultimaAvalicação = new UsuarioServicoAvaliacao(
                usuarioId: idUser,
                servicoId: idService,
                dataUltimaAvaliacao: DateTime.UtcNow);

            await context.AddAsync(ultimaAvalicação);

            await context.SaveChangesAsync();

        }

        public async Task UpdateDataUltimaAvalicaoPorServico(Guid idUser, Guid idService)
        {
            var ultimaAvalicação = await context.UsuarioServicoAvaliacoes
                                         .Where(x => (x.UsuarioId == idUser)
                                          && (x.ServicoId == idService))
                                         .FirstOrDefaultAsync();

            if (ultimaAvalicação != null)
            {
                ultimaAvalicação.Update(dataUltimaAvaliacao: DateTime.UtcNow);
                await context.SaveChangesAsync();
            }
            else {
                await SalvarDataUltimaAvaliacaoPorServico(idUser, idService);
            }
        }

        public async Task<Dictionary<Guid, DateTime?>> ListUlitmaAvaliacaoUser(Guid id)
        {

            var servico = await ultimaAvalicaoPorServico.GetUltimaAvaliacaiServicoFromUser(id);

            return servico;
        }
    }
}
