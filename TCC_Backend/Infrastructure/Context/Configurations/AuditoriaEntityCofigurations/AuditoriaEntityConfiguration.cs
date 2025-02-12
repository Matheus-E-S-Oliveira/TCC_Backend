using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Auditorias;

namespace TCC_Backend.Infrastructure.Context.Configurations.AuditoriasEntityCofiguration
{
    public class AuditoriaEntityConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("auditoria");


        }
    }
}
