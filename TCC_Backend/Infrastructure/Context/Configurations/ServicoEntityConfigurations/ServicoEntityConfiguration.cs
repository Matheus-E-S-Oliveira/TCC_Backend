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

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Titulo)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.NumeroDeAvalicoes)
                .IsRequired();

            builder.HasMany(x => x.Avaliacoes)
                .WithOne(x => x.Servico)
                .HasForeignKey(x => x.IdServico)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Historicos)
                .WithOne(x => x.Servico)
                .HasForeignKey(x => x.IdServico)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.UsuarioServicoAvaliacoes)
                .WithOne(x => x.Servico)
                .HasForeignKey(x => x.ServicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
