using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Persistance.Configurations;

public class CategoryOfRouteConfiguration : IEntityTypeConfiguration<CategoryOfRoute> {

    public void Configure(EntityTypeBuilder<CategoryOfRoute> builder) {
        builder.HasKey(cr => cr.Id);

        builder.Property(cr => cr.Name)
            .HasMaxLength(50);
        
        builder.Property(cr => cr.Description)
            .HasMaxLength(1000);
    }
}