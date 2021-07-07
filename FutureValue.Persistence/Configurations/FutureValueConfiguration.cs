using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FutureValue.Domain;

namespace FutureValue.Persistence.Configurations
{
    public class FutureValueConfiguration
        : IEntityTypeConfiguration<FutureValues>
    {
        public void Configure(EntityTypeBuilder<FutureValues> builder)
        {
            builder.Property(p => p.FutureValuesId)
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(p => p.PresentValue)
                .IsRequired()
                .HasColumnType("Float");

            builder.Property(p => p.LowerBoundInterest)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p => p.UpperBoundInterest)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p => p.IncrementalRate)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p => p.MaturityYears)
                .IsRequired();

            builder.Property(p => p.ExecutionDate)
                .IsRequired()
                .HasColumnType("DateTime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
