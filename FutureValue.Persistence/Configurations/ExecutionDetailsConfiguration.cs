using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FutureValue.Domain;

namespace FutureValue.Persistence.Configurations
{
    public class ExecutionDetailsConfiguration
        : IEntityTypeConfiguration<ExecutionDetails>
    {
        public void Configure(EntityTypeBuilder<ExecutionDetails> builder)
        {
            builder.Property(p => p.ExecutionDetailsId)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(p => p.Year)
                .IsRequired();

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnType("Float");

            builder.Property(p => p.InterestRate)
                .IsRequired();

            builder.Property(p => p.FutureValue)
                .IsRequired()
                .HasColumnType("Float");
        }
    }
}
