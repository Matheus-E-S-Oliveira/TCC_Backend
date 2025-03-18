namespace TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys
{
    public interface IUsuarioServicoAvaliacaoRepository
    {
        Task UpdateDataUltimaAvalicaoPorServico(Guid idUser, Guid idService);

        Task<Dictionary<Guid, DateTime?>> ListUlitmaAvaliacaoUser(Guid idUser);
    }
}
