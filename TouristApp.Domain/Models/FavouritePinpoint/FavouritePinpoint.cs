using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.FavouritePinpoint;

public class FavouritePinpoint : AuditableEntity {
    public Guid UserId { get; private set; }
    public Guid PinpointId { get; private set; }

    private FavouritePinpoint() { }

    public static FavouritePinpoint Create(Guid userId, Guid pinpointId) {
        var favouriteRoute = new FavouritePinpoint()
        {
            UserId = userId,
            PinpointId = pinpointId
        };
        
        favouriteRoute.Update();
        
        return favouriteRoute;
    }
}