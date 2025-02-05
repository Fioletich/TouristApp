using MediatR;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.DeleteFavouriteRoute;

public record DeleteFavouriteRouteRequest(Guid UserId, Guid RouteId) : IRequest;