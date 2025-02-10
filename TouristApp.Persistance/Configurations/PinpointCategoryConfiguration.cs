using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Persistance.Configurations;

public class PinpointCategoryConfiguration : IEntityTypeConfiguration<PinpointCategory>{

    public void Configure(EntityTypeBuilder<PinpointCategory> builder) {
        builder.HasKey(pc => new { pc.PinpointId, pc.CategoryOfPinpointId });
        
        builder.HasOne<Pinpoint>()
            .WithMany()
            .HasForeignKey(p => p.PinpointId);

        builder.HasOne<CategoryOfPinpoint>()
            .WithMany()
            .HasForeignKey(p => p.CategoryOfPinpointId);
    }
}