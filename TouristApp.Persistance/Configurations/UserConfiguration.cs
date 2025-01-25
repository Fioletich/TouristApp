using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.HasKey(b => b.Id);

        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
        
        builder.HasMany(u => u.Pinpoints)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.Routes)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(u => u.RoleId)
            .IsRequired();
        
        builder.Property(u => u.City)
            .HasMaxLength(40);
        
        builder.Property(u => u.Password)
            .HasMaxLength(40)
            .IsRequired();
        
        builder.Property(u => u.Login)
            .HasMaxLength(40)
            .IsRequired();
    }
}