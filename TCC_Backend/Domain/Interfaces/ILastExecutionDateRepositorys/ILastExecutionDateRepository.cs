namespace TCC_Backend.Domain.Interfaces.ILastExecutionDateRepositorys
{
    public interface ILastExecutionDateRepository
    {
        Task<DateTime?> GetLastExecutionDateAsync();
        Task SaveExecutionDateAsync(DateTime date);
    }
}
