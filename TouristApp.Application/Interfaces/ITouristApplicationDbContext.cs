using Microsoft.EntityFrameworkCore;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Interfaces;

public interface ITouristApplicationDbContext {
    public DbSet<PinPoint> PinPoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<TouristRoute> TouristRoutes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Featured> Featureds { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PinpointCategory> PinpointCategories { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}