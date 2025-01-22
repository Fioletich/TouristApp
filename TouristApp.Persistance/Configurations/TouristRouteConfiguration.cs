using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance.Configurations;

public class TouristRouteConfiguration : IEntityTypeConfiguration<TouristRoute>{

    public void Configure(EntityTypeBuilder<TouristRoute> builder) {
        builder.HasKey(tr => tr.Id);
    }
}