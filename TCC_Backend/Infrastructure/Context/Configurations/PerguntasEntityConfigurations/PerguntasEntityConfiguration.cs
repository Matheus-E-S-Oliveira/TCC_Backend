using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Perguntas;

namespace TCC_Backend.Infrastructure.Context.Configurations.PerguntasEntityConfigurations
{
    public class PerguntasEntityConfiguration : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.ToTable("perguntas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.Numero);

            builder.Property(x => x.Question);
        }
    }
}
