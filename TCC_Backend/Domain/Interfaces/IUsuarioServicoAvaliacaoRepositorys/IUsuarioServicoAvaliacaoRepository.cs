namespace TCC_Backend.Domain.Interfaces.IUsuarioServicoAvaliacaoRepositorys
{
    public interface IUsuarioServicoAvaliacaoRepository
    {
        Task UpdateDataUltimaAvalicaoPorServico(Guid idUser, Guid idService);
    }
}
