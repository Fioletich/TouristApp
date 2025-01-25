using MediatR;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;

public record CreateRouteRequest(Guid UserId, string Name, string Description) : IRequest<Guid>;