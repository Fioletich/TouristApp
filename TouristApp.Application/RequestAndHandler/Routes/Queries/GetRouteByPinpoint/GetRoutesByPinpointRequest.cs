using MediatR;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRouteByPinpoint;

public record GetRoutesByPinpointRequest(Guid pinpointId) : IRequest<IEnumerable<Route>>;