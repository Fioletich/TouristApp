using MediatR;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoutesOfRoute;

public record GetPinpointRoutesOfRouteRequest(Guid RouteId) : IRequest<IEnumerable<PinpointRoute>>;