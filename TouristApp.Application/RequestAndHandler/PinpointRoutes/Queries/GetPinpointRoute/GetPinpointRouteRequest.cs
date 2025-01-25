using MediatR;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;

public record GetPinpointRouteRequest(Guid PinpointId, Guid RouteId) : IRequest<PinpointRoute>;