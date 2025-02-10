using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Persistance.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role> {

    public void Configure(EntityTypeBuilder<Role> builder) {
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
        
        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}