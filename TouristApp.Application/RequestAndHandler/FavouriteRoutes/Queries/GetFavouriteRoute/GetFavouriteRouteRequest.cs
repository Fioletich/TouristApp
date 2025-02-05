using MediatR;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetFavouriteRoute;

public record GetFavouriteRouteRequest(Guid UserId, Guid RouteId) : IRequest<FavouriteRoute>;