using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Avaliacoes;

namespace TCC_Backend.Infrastructure.Context.Configurations.AvaliacoesEntityConfigurations
{
    public class AvalicacaoEnityConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable("avalicao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.Nota)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.Property(x => x.DataAvalicao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

        }
    }
}
