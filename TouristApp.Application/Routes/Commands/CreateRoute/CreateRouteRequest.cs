using MediatR;

namespace TouristApp.Application.Routes.Commands.CreateRoute;

public class CreateRouteRequest : IRequest<Guid> {
    public string Name { get; set; }
    public string Description { get; set; }
}