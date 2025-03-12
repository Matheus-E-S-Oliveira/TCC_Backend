using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Adms;

namespace TCC_Backend.Infrastructure.Context.Configurations.AdmEntityConfigurations
{
    public class AdmEntityConfiguration : IEntityTypeConfiguration<Adm>
    {
        public void Configure(EntityTypeBuilder<Adm> builder)
        {
            builder.ToTable("adm");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasMaxLength(20);
        }
    }
}
