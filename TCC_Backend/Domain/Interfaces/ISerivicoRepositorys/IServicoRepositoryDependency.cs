namespace TCC_Backend.Domain.Interfaces.ISerivicoRepositorys
{
    public interface IServicoRepositoryDependency
    {
        Task ZerarNumeroDeAvaliacoes(Guid id);
    }
}
