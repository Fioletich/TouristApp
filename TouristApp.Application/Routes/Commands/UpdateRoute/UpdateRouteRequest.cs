using MediatR;

namespace TouristApp.Application.Routes.Commands.UpdateRoute;

public class UpdateRouteRequest : IRequest {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}