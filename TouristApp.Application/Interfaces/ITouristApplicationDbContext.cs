using Microsoft.EntityFrameworkCore;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Interfaces;

public interface ITouristApplicationDbContext {
    public DbSet<PinPoint> PinPoints { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<TouristRoute> TouristRoutes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}