using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

public record GetRouteRequest(Guid Id) : IRequest<Route>;