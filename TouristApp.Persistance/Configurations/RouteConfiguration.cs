using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>{
    public void Configure(EntityTypeBuilder<Route> builder) {
        builder.HasKey(x => x.Id);
    }
}