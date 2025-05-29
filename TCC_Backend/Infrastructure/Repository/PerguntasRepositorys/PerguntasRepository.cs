using Microsoft.EntityFrameworkCore;
using TCC_Backend.Application.Dtos.PerguntasDtos;
using TCC_Backend.Domain.Interfaces.IPerguntasRepositorys;
using TCC_Backend.Domain.Models.Perguntas;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Infrastructure.Repository.PerguntasRepositorys
{
    public class PerguntasRepository(TccBackendContext context) : IPerguntasRepository
    {
        public async Task<int> SavePergunta(Guid idServico, List<PerguntaDto> perguntas)
        {
            var result = perguntas.Select(p => new Pergunta(
                numero: p.Numero,
                question: p.Question,
                idServico: idServico)).ToList();

            await context.Perguntas.AddRangeAsync(result);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdatePergunta(Guid idServico, List<PerguntaDto> perguntas)
        {
            var perguntasExistentes = await GetPerguntasByServicoId(idServico);

            if (perguntasExistentes.Count == 0) return await SavePergunta(idServico, perguntas);

            foreach (var pergunta in perguntasExistentes)
            {
                var perguntaDto = perguntas.FirstOrDefault(p => p.IdPergunta == pergunta.Id);

                if (perguntaDto != null)
                {
                    pergunta.Update(
                        numero: perguntaDto.Numero,
                        question: perguntaDto.Question
                    );
                }
            }

            return await context.SaveChangesAsync();
        }

        private async Task<List<Pergunta>> GetPerguntasByServicoId(Guid idServico)
        {
            return await context.Perguntas
                .Where(p => p.IdServico == idServico)
                .ToListAsync();
        }
    }
}