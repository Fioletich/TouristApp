using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance;

public class TouristApplicationDbContext : DbContext, ITouristApplicationDbContext {
    public DbSet<Pinpoint> Pinpoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PinpointRoute> PinpointRoutes { get; set; }

    public TouristApplicationDbContext() { }

    public TouristApplicationDbContext(DbContextOptions<TouristApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}