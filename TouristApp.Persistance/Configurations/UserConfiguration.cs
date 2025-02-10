using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.HasKey(b => b.Id);
        
        /*
        builder
            .HasMany(r => r.FavoriteRoutes)
            .WithMany(p => p.Followers)
            .UsingEntity<FavouriteRoute>(
                i =>
                { 
                    return i.HasOne<Route>()
                        .WithMany()
                        .HasForeignKey(pr => pr.RouteId)
                        .OnDelete(DeleteBehavior.NoAction);
                },
                j =>
                {
                    return j.HasOne<User>()
                        .WithMany()
                        .HasForeignKey(pr => pr.UserId)
                        .OnDelete(DeleteBehavior.NoAction);
                });
        */
        
        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
        
        builder.HasMany(u => u.Routes)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(u => u.RoleId)
            .IsRequired();
        
        builder.Property(u => u.City)
            .HasMaxLength(40);
        
        builder.Property(u => u.Password)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(u => u.Login)
            .HasMaxLength(50)
            .IsRequired();
    }
}