using MediatR;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;

public record UpdateRouteRequest(Guid Id, string? Name, string? Description) : IRequest;