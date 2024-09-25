using MediatR;

namespace TouristApp.Application.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequest : IRequest<Guid> {
    public Guid RouteId { get; set; }
    public Guid PinPointId { get; set; }
}