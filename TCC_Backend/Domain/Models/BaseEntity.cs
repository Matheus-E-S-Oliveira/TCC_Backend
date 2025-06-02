using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TCC_Backend.Domain.Interfaces;

namespace TCC_Backend.Domain.Models
{
    public class BaseEntity : IBaseEnitty
    {
        public Guid Id { get; protected set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataAtualizacao { get; private set; }

        public virtual void AtualizarDataDeEstados(EntityState entityState)
        {
            if (entityState == EntityState.Added)
            {
                DataCriacao = DateTime.UtcNow;
            }
            else if (entityState == EntityState.Modified)
            {
                DataAtualizacao = DateTime.UtcNow;
            }
        }
    }
}
