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

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(a => a.Entidade)
           .IsRequired()
           .HasMaxLength(100);

            builder.Property(a => a.ChavePrimaria)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Acao)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.Propriedade)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(a => a.ValorAntigo)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(a => a.ValorNovo)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(a => a.Usuario)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
