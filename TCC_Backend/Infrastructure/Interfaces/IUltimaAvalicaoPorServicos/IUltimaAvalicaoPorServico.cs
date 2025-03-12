namespace TCC_Backend.Infrastructure.Interfaces.IUltimaAvalicaoPorServicos
{
    public interface IUltimaAvalicaoPorServico
    {
        Task<Dictionary<Guid, DateTime?>> GetUltimaAvaliacaiServicoFromUser(Guid userId);
    }
}
