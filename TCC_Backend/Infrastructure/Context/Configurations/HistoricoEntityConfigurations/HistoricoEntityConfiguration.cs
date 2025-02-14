using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Historicos;

namespace TCC_Backend.Infrastructure.Context.Configurations.HistoricoEntityConfigurations
{
    public class HistoricoEntityConfiguration : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("historico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.MediaCategoria1)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(x => x.MediaCategoria2)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

            builder.Property(x => x.MediaCategoria3)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

            builder.Property(x => x.MediaCategoria4)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

            builder.Property(x => x.MediaCategoria5)
               .HasColumnType("decimal(10,2)")
               .IsRequired();

            builder.Property(x => x.DataReferencia)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();
        }
    }
}
