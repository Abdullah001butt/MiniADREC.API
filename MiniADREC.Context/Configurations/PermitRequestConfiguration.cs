using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniADREC.Domain.Entities;

namespace MiniADREC.Context.Configurations
{
    public class PermitRequestConfiguration : IEntityTypeConfiguration<PermitRequest>
    {
        public void Configure(EntityTypeBuilder<PermitRequest> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Type).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Status).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.RequestedAt).IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Plot)
                .WithMany()
                .HasForeignKey(p => p.PlotId);
        }
    }
}
