namespace TCC_Backend.Application.Interfaces.Servicos.IServicoBackgroundServices
{
    public interface IServicoBackgroundService
    {
        Task AtualizarServicosAsync(CancellationToken cancellationToken);
    }
}
