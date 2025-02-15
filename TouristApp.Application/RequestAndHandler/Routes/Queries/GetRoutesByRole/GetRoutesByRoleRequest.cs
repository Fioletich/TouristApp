using MediatR;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByRole;

public record GetRoutesByRoleRequest(Guid roleId) : IRequest<IEnumerable<Route>>;