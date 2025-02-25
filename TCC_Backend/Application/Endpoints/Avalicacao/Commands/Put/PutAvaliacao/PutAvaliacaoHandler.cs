using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_Backend.Infrastructure.Context.AppDbContext;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;

namespace TCC_Backend.Application.Endpoints.Avalicacao.Commands.Put.PutAvaliacao
{
    public class PutAvaliacaoHandler(TccBackendContext context, IServicoRepository servicoRepository) : BaseApiController
    {
        public async Task<IActionResult> Handle(Guid id, PutAvaliacaoRequest request)
        {
            var avaliacoes = await context.Avaliacoes
                                .Where(x => x.IdServico == id)
                                .ToListAsync();

            if (avaliacoes.Count == 0) return Error("Serviço não encontrado");
            if (request.Respostas == null) return Error("Erro ao salvar a avaliação");

            bool hasChanges = false;

            foreach (var avaliacao in avaliacoes)
            {
                if (request.Respostas.TryGetValue((int)avaliacao.Categoria, out int nota))
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
                return Error("Nenhuma alteração foi feita.");

            int saved = await context.SaveChangesAsync();

            if (saved > 0) {
                await servicoRepository.AtualizarNumeroAvaliacoes(id);
                return OkResponse("Avaliação salva com sucesso!");
            }
            else
                return HandleException();

        }
    }
}
