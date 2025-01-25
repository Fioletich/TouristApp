using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.CreatePinpointRoute;

public record CreatePinpointRouteRequest(Guid RouteId, Guid PinpointId) : IRequest;