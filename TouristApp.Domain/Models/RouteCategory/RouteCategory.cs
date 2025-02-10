using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.RouteCategory;

public class RouteCategory : AuditableEntity {
    public Guid RouteId {  get; private set; }
    public Guid CategoryOfRouteId { get; private set; }
    
    private RouteCategory() { }

    public static RouteCategory Create(Guid routeId, Guid categoryOfRouteId) {
        var routeCategory = new RouteCategory()
        {
            RouteId = routeId,
            CategoryOfRouteId = categoryOfRouteId
        };
        
        routeCategory.Update();
        
        return routeCategory;
    }
}