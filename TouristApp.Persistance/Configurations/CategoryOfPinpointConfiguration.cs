using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Persistance.Configurations;

public class CategoryOfPinpointConfiguration : IEntityTypeConfiguration<CategoryOfPinpoint>{
    public void Configure(EntityTypeBuilder<CategoryOfPinpoint> builder) {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .HasMaxLength(50);
        
        builder.Property(c => c.Description)
            .HasMaxLength(1000);
    }
}