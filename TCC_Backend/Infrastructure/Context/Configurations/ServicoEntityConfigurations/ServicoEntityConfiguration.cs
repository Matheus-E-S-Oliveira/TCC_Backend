using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Servicos;

namespace TCC_Backend.Infrastructure.Context.Configurations.ServicoEntityConfigurations
{
    public class ServicoEntityConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("servico");

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.NumeroDeAvalicoes)
                .IsRequired();
        }
    }
}
