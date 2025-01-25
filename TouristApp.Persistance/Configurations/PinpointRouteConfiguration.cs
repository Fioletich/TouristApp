using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Persistance.Configurations;

public class PinpointRouteConfiguration : IEntityTypeConfiguration<PinpointRoute>{

    public void Configure(EntityTypeBuilder<PinpointRoute> builder) {
        builder.HasOne<Route>()
            .WithMany()
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne<Pinpoint>()
            .WithMany()
            .HasForeignKey(p => p.PinpointId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}