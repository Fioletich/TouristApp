using MediatR;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinpointsByRoute;

public record GetPinpointsByRouteRequest(Guid RouteId) : IRequest<IEnumerable<Pinpoint>>;