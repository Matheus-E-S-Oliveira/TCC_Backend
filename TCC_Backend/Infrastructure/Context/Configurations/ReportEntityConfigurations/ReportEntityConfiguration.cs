using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.Reports;

namespace TCC_Backend.Infrastructure.Context.Configurations.ReportEntityConfigurations
{
    public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("report");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);

            builder.Property(x => x.ReportType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.WantsContact)
                .IsRequired();

            builder.Property(x => x.ContactEmail)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ErrorCategory)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.SuggestionCategory)
                .HasMaxLength(22)
                .IsRequired(false);
        }
    }
}
