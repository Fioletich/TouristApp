using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.FavouriteRoute;

public class FavouriteRoute : AuditableEntity {
    public Guid UserId { get; private set; }
    public Guid RouteId { get; private set; }

    private FavouriteRoute() { }

    public static FavouriteRoute Create(Guid userId, Guid routeId) {
        var favouriteRoute = new FavouriteRoute()
        {
            UserId = userId,
            RouteId = routeId
        };
        
        favouriteRoute.Update();
        
        return favouriteRoute;
    }
}