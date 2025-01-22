using MediatR;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequest : IRequest<Guid> {
    public Guid RouteId { get; set; }
    public Guid PinPointId { get; set; }
}