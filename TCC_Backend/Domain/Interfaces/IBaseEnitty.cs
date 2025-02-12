using Microsoft.EntityFrameworkCore;

namespace TCC_Backend.Domain.Interfaces
{
    public interface IBaseEnitty
    {
        void AtualizarDataDeEstados(EntityState entityState);
    }
}
