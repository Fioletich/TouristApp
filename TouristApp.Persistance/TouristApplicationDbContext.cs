using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Persistance;

public class TouristApplicationDbContext : DbContext, ITouristApplicationDbContext {

    public DbSet<PinPoint> PinPoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<TouristRoute> TouristRoutes { get; set; }
    public DbSet<User> Users { get; set; }

    public TouristApplicationDbContext(DbContextOptions<TouristApplicationDbContext> options) : base(options) {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Server=localhost;Port=1111;Database=postgres;UserName=postgres;Password=123789pr;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<PinPoint>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Route>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<TouristRoute>()
            .HasKey(t => t.Id);
    }
}