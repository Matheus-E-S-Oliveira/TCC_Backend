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

            builder.Property(x => x.Nota)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.Property(x => x.DataAvalicao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();
        }
    }
}
