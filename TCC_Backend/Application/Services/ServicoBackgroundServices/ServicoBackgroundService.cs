using TCC_Backend.Application.Interfaces.IServicoBackgroundServices;
using TCC_Backend.Infrastructure.Context.AppDbContext;

namespace TCC_Backend.Application.Services.ServicoBackgroundServices
{
    public class ServicoBackgroundService(IServiceProvider services) : IHostedService, IDisposable, IServicoBackgroundService
    {
        private Timer? _timer;

        public class TaskState
        {
            public CancellationToken CancellationToken { get; set; }
        }


        public async Task AtualizarServicosAsync(CancellationToken cancellationToken)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TccBackendContext>();

            var servicos = context.Servicos.ToList();
            foreach (var servico in servicos)
            {
                servico.Update(numeroDeAvaliacoes: 0);
                context.Servicos.Update(servico);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _timer?.Dispose();
            GC.SuppressFinalize(this);
        }

        private async void ExecuteTask(object? state)
        {
            if (state == null) return;

            var taskState = (TaskState)state;
            var cancellationToken = taskState.CancellationToken;

            await AtualizarServicosAsync(cancellationToken);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var nextFirstDay = new DateTime(now.Year, now.Month, 1).AddMonths(1);
            var timeToWait = nextFirstDay - now;

            var taskState = new TaskState { CancellationToken = cancellationToken };


            _timer = new Timer(ExecuteTask, taskState, timeToWait, TimeSpan.FromDays(30));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
