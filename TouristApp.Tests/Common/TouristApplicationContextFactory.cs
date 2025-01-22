using Microsoft.EntityFrameworkCore;
using TouristApp.Domain.Models;
using TouristApp.Persistance;

namespace TouristApp.Tests.Common;

public class TouristApplicationContextFactory {
    public static Guid PinpointIdForDelete = Guid.NewGuid();
    public static Guid PinpointIdForUpdate = Guid.NewGuid();
    public static Guid PinpointIdForGet = Guid.NewGuid();

    public static TouristApplicationDbContext CreateContext() {
        var options = new DbContextOptionsBuilder<TouristApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var context = new TouristApplicationDbContext(options);
        
        context.Database.EnsureCreated();

        context.Pinpoints.AddRange(
            new Pinpoint()
            {
                Id = Guid.Parse("088BAA6B-91BC-426A-BBEE-6DD02CBBB38B"),
                Name = "Pinpoint0",
                Description = "Description0",
                AudioUrl = string.Empty,
                XCoordinate = 2.0m,
                YCoordinate = 3.0m
            },
            new Pinpoint()
            {
                Id = PinpointIdForGet,
                Name = "Pinpoint1",
                Description = "Description1",
                AudioUrl = string.Empty,
                XCoordinate = 2.0m,
                YCoordinate = 3.0m
            },
            new Pinpoint()
            {
                Id = PinpointIdForDelete,
                Name = "Pinpoint2",
                Description = "Description2",
                AudioUrl = string.Empty,
                XCoordinate = 2.0m,
                YCoordinate = 3.0m
            },
            new Pinpoint()
            {
                Id = PinpointIdForUpdate,
                Name = "Pinpoint3",
                Description = "Description3",
                AudioUrl = string.Empty,
                XCoordinate = 2.0m,
                YCoordinate = 3.0m
            });
        
        context.SaveChanges();
        
        return context;
    }

    public static void Destroy(TouristApplicationDbContext context) {
        context.Database.EnsureDeleted();
        
        context.Dispose();
    }
}