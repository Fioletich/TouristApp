using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;
using TouristApp.Domain.Models.CategoryOfRoute;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointCategory;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.RouteCategory;
using TouristApp.Domain.Models.User;

namespace TouristApp.Persistance;

public class TouristApplicationDbContext : DbContext, ITouristApplicationDbContext {
    public DbSet<Pinpoint> Pinpoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CategoryOfPinpoint> CategoriesOfPinpoints { get; set; }
    public DbSet<CategoryOfRoute> CategoriesOfRoutes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PinpointRoute> PinpointRoutes { get; set; }
    public DbSet<PinpointCategory> PinpointCategories { get; set; }
    public DbSet<RouteCategory> RouteCategories { get; set; }
    public DbSet<FavouriteRoute> FavouriteRoutes { get; set; }
    public DbSet<FavouritePinpoint> FavouritePinpoints { get; set; }

    public TouristApplicationDbContext() { }

    public TouristApplicationDbContext(DbContextOptions<TouristApplicationDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}