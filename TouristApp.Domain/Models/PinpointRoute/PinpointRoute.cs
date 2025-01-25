using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.PinpointRoute;

public class PinpointRoute : AuditableEntity {
    public Guid PinpointId { get; private set; }
    public Guid RouteId { get; private set; }
    

    private PinpointRoute() { }

    public static PinpointRoute Create(Guid routeId, Guid pinpointId) {
        var pinpointRoute = new PinpointRoute()
        {
            RouteId = routeId,
            PinpointId = pinpointId
        };
        
        pinpointRoute.Update();
        
        return pinpointRoute;
    }
}