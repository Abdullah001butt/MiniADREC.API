using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniADREC.Domain.Entities;

namespace MiniADREC.Context.Configurations
{
    public class PlotConfiguration : IEntityTypeConfiguration<Plot>
    {
        public void Configure(EntityTypeBuilder<Plot> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PlotNumber).IsRequired().HasMaxLength(50);
            builder.Property(p => p.District).HasMaxLength(100);
            builder.Property(p => p.LandUse).HasMaxLength(100);
            builder.Property(p => p.OwnerName).HasMaxLength(100);
        }
    }
}
