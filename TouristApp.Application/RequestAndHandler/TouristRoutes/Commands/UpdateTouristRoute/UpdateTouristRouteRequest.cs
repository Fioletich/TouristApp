using MediatR;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.UpdateTouristRoute;

public class UpdateTouristRouteRequest : IRequest {
    public Guid Id { get; set; }
    public Guid RouteId { get; set; }
    public Guid PinPointId { get; set; }
}