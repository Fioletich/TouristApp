using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance.Configurations;

public class FavouritePinpointConfiguration : IEntityTypeConfiguration<FavouritePinpoint> {

    public void Configure(EntityTypeBuilder<FavouritePinpoint> builder) {
        builder.HasKey(fr => new { fr.UserId, fr.PinpointId });
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(fr => fr.UserId);

        builder.HasOne<Pinpoint>()
            .WithMany()
            .HasForeignKey(fr => fr.PinpointId);
    }
}