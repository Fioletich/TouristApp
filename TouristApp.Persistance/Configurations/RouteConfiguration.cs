using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>{
    public void Configure(EntityTypeBuilder<Route> builder) {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(r => r.Pinpoints)
            .WithMany(p => p.Routes)
            .UsingEntity<PinpointRoute>(
                i =>
                { 
                    return i.HasOne<Pinpoint>()
                        .WithMany()
                        .HasForeignKey(pr => pr.PinpointId)
                        .OnDelete(DeleteBehavior.NoAction);
                },
                j =>
                {
                    return j.HasOne<Route>()
                        .WithMany()
                        .HasForeignKey(pr => pr.RouteId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        
        /*
        builder
            .HasMany(r => r.Followers)
            .WithMany(p => p.Routes)
            .UsingEntity<FavouriteRoute>(
                i =>
                { 
                    return i.HasOne<User>()
                        .WithMany()
                        .HasForeignKey(pr => pr.UserId)
                        .OnDelete(DeleteBehavior.NoAction);
                },
                j =>
                {
                    return j.HasOne<Route>()
                        .WithMany()
                        .HasForeignKey(pr => pr.RouteId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        */
        
        builder.HasOne(r => r.User)
            .WithMany(u => u.Routes)
            .HasForeignKey(r => r.UserId);
        
        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();
    }
}