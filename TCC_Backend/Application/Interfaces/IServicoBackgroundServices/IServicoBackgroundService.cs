namespace TCC_Backend.Application.Interfaces.IServicoBackgroundServices
{
    public interface IServicoBackgroundService
    {
        Task AtualizarServicosAsync(CancellationToken cancellationToken);
    }
}
