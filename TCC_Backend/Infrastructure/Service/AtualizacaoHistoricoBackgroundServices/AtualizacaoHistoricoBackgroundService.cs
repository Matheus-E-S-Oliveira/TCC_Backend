using TCC_Backend.Application.Interfaces.Servicos.IHistoricoServices;
using TCC_Backend.Domain.Interfaces.ILastExecutionDateRepositorys;
using TCC_Backend.Domain.Interfaces.ISerivicoRepositorys;

namespace TCC_Backend.Infrastructure.Service.AtualizacaoHistoricoBackgroundServices
{
    public class AtualizacaoHistoricoBackgroundService(
                                                       IServiceScopeFactory serviceScopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var lastExecutionDateRepository = scope.ServiceProvider.GetRequiredService<ILastExecutionDateRepository>();
                    var lastExecutionDate = await lastExecutionDateRepository.GetLastExecutionDateAsync();

                    var dataAgendada = GetUltimoDiaMesPassado();
                    var precisaExecutar = lastExecutionDate == null || lastExecutionDate.Value.Month != dataAgendada.Month;

                    if (precisaExecutar)
                    {
                        await ExecuteUpdateAsync(scope.ServiceProvider, dataAgendada);
                        await lastExecutionDateRepository.SaveExecutionDateAsync(dataAgendada);
                    }
                }

                var delay = GetDelayToEndOfMonth();

                await Task.Delay(delay, stoppingToken);
            }
        }

        private async Task ExecuteUpdateAsync(IServiceProvider serviceProvider, DateTime dataReferencia)
        {
            var servicoRepository = serviceProvider.GetRequiredService<IServicoRepository>();
            var historicoService = serviceProvider.GetRequiredService<IHistoricoService>();

            var listaServicos = await servicoRepository.GetAllServicosIdsAndNumeroAvalicoesAsync();

            foreach (var servico in listaServicos)
            {
                await historicoService.AtualizarHistoricoEZerarAvaliacoesAsync(dataReferencia, servico.Id, servico.NumeroDeAvalicoes);
            }
        }


        private static TimeSpan GetDelayToEndOfMonth()
        {
            var now = DateTime.UtcNow;
            var nextMonth = new DateTime(now.Year, now.Month, 1).AddMonths(1);
            var endOfMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1).AddDays(-1);
            return endOfMonth - now;
        }

        private static DateTime GetUltimoDiaMesPassado()
        {
            var now = DateTime.UtcNow;
            var primeiroDiaMesAtual = new DateTime(now.Year, now.Month, 1);
            return primeiroDiaMesAtual.AddDays(-1); // Último dia do mês passado
        }

    }
}
