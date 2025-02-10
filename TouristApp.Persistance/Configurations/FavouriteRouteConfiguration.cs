using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance.Configurations;

public class FavouriteRouteConfiguration : IEntityTypeConfiguration<FavouriteRoute> {

    public void Configure(EntityTypeBuilder<FavouriteRoute> builder) {
        builder.HasKey(table => new { table.RouteId, table.UserId });
        
        builder.HasOne<Route>()
            .WithMany()
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}