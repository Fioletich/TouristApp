using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoutesOfRoute;

public record DeletePinpointRoutesOfRouteRequest(Guid RouteId) : IRequest;