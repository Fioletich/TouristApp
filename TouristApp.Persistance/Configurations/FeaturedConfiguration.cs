using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class FeaturedConfiguration : IEntityTypeConfiguration<Featured>{

    public void Configure(EntityTypeBuilder<Featured> builder) {
        builder.HasKey(f => f.Id);
    }
}