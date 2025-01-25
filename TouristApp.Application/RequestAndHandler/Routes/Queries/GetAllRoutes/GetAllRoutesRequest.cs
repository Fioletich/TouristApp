using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;

public record GetAllRoutesRequest : IRequest<IEnumerable<Route>>;