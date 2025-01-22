using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class PinpointConfiguration : IEntityTypeConfiguration<Pinpoint> {
    public void Configure(EntityTypeBuilder<Pinpoint> builder) {
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.XCoordinate)
            .HasPrecision(8, 6);
        
        builder.Property(p => p.YCoordinate)
            .HasPrecision(8, 6);
    }
}