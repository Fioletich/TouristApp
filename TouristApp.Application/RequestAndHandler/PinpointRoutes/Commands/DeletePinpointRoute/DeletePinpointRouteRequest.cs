using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;

public record DeletePinpointRouteRequest(Guid RouteId, Guid PinpointId) : IRequest;