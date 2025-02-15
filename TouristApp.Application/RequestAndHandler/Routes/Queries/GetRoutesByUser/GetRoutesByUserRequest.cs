using MediatR;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByUser;

public record GetRoutesByUserRequest(Guid UserId) : IRequest<IEnumerable<Route>>;