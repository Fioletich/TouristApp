using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>{
    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.HasKey(c => c.Id);
    }
}