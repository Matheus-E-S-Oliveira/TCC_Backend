using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;

namespace TCC_Backend.Infrastructure.Context.Configurations.UsuarioServicosAvaliacao
{
    public class UsuarioServicoAvaliacaoEntityConfiguration : IEntityTypeConfiguration<UsuarioServicoAvaliacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioServicoAvaliacao> builder)
        {
            builder.ToTable("usuario_servicos_avaliacoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.DataUltimaAvaliacao)
                .IsRequired();
        }
    }
}
