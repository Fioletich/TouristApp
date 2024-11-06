using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance;

public class TouristApplicationDbContext : DbContext, ITouristApplicationDbContext {

    public DbSet<PinPoint> PinPoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<TouristRoute> TouristRoutes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Featured> Featureds { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PinpointCategory> PinpointCategories { get; set; }

    public TouristApplicationDbContext(DbContextOptions<TouristApplicationDbContext> options) : base(options) {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PinPoint>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Route>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<TouristRoute>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Featured>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<PinpointCategory>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<PinPoint>()
            .Property(p => p.XCoordinate)
            .HasPrecision(8, 6);
        modelBuilder.Entity<PinPoint>()
            .Property(p => p.YCoordinate)
            .HasPrecision(8, 6);
    }
}