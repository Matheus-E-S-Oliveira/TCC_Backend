using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC_Backend.Domain.Models.LastExecutions;

namespace TCC_Backend.Infrastructure.Context.Configurations.LastExecutionEntityConfigurations
{
    public class LastExecutionEntityConfiguration : IEntityTypeConfiguration<LastExecution>
    {
        public void Configure(EntityTypeBuilder<LastExecution> builder)
        {

            builder.ToTable("last_execution");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.LastExecutionDate)
                .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
                .IsRequired(false);
        }
    }

}
