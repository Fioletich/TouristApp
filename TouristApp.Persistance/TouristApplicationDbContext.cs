using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance;

public class TouristApplicationDbContext(DbContextOptions<TouristApplicationDbContext> options)
    : DbContext(options), ITouristApplicationDbContext {
    public DbSet<Pinpoint> Pinpoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<TouristRoute> TouristRoutes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Featured> Featureds { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PinpointCategory> PinpointCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}