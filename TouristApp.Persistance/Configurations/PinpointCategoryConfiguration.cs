using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class PinpointCategoryConfiguration : IEntityTypeConfiguration<PinpointCategory> {
    public void Configure(EntityTypeBuilder<PinpointCategory> builder) {
        builder.HasKey(pc => pc.Id);
    }
}
