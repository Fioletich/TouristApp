using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Persistance.Configurations;

public class PinpointConfiguration : IEntityTypeConfiguration<Pinpoint> {
    public void Configure(EntityTypeBuilder<Pinpoint> builder) {
        builder.HasKey(p => p.Id);

        builder
            .HasMany(p => p.Routes)
            .WithMany(r => r.Pinpoints)
            .UsingEntity<PinpointRoute>(
                i =>
                { 
                    return i.HasOne<Route>()
                        .WithMany()
                        .HasForeignKey(pr => pr.RouteId)
                        .OnDelete(DeleteBehavior.NoAction);
                },
                j =>
                {
                    return j.HasOne<Pinpoint>()
                        .WithMany()
                        .HasForeignKey(pr => pr.PinpointId)
                        .OnDelete(DeleteBehavior.NoAction);
                });

        builder.HasOne(p => p.User)
            .WithMany(u => u.Pinpoints)
            .HasForeignKey(p => p.UserId);
        
        builder.Property(p => p.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(p => p.XCoordinate)
            .HasPrecision(8, 6);
        
        builder.Property(p => p.YCoordinate)
            .HasPrecision(8, 6);
    }
}