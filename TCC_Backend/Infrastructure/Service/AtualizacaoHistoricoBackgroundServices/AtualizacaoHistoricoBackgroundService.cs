using TCC_Backend.Application.Interfaces.IHistoricoService;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;

namespace TCC_Backend.Infrastructure.Service.AtualizacaoHistoricoBackgroundServices
{
    public class AtualizacaoHistoricoBackgroundService(IHistoricoService historicoService, IServicoRepository servicoRepository) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(GetDelayToEndOfMonth(), stoppingToken);

            var listaServicos = await servicoRepository.GetAllServicosIdsAndNumeroAvalicoesAsync();

            foreach (var servico in listaServicos)
            {
                await historicoService.AtualizarHistoricoEZerarAvaliacoesAsync(DateTime.UtcNow, servico.Id, servico.NumeroDeAvalicoes);
            }

            //await historicoService.AtualizarHistoricoEZerarAvaliacoesAsync(DateTime.UtcNow, idServico, numeroDeAvaliacoes);
            //Obsv: analizar coportamento por causa da data que pode atrasar o funcionamento esperado
        }

        private static TimeSpan GetDelayToEndOfMonth()
        {
            var now = DateTime.UtcNow;
            var nextMonth = new DateTime(now.Year, now.Month, 1).AddMonths(1);
            var endOfMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1).AddDays(-1);
            return endOfMonth - now;
        }
    }
}
