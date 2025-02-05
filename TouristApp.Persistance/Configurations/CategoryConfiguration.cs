using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>{
    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .HasMaxLength(255);
        
        builder.Property(c => c.Description)
            .HasMaxLength(255);
    }
}