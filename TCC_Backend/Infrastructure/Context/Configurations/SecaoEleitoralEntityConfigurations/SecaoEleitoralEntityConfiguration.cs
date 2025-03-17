using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.SecaoEleitorais;

namespace TCC_Backend.Infrastructure.Context.Configurations.SecaoEleitoralEntityConfigurations
{
    public class SecaoEleitoralEntityConfiguration : IEntityTypeConfiguration<SecaoEleitoral>
    {
        public void Configure(EntityTypeBuilder<SecaoEleitoral> builder)
        {
            builder.ToTable("secao_eleitoral");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.Numero)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(x => x.LocalVotacao)
                .IsRequired(false);

            builder.Property(x => x.ZonaEleitoral)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .IsRequired(false);

            builder.Property(x => x.Cidade)
                .IsRequired(false);
        }
    }
}
