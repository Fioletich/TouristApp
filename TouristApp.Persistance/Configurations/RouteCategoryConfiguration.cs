using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.CategoryOfRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Persistance.Configurations;

public class RouteCategoryConfiguration : IEntityTypeConfiguration<RouteCategory> {

    public void Configure(EntityTypeBuilder<RouteCategory> builder) {
        builder.HasKey(rc => new { rc.RouteId, rc.CategoryOfRouteId });

        builder.HasOne<Route>()
            .WithMany()
            .HasForeignKey(rc => rc.RouteId);
        
        builder.HasOne<CategoryOfRoute>()
            .WithMany()
            .HasForeignKey(rc => rc.CategoryOfRouteId);
    }
}