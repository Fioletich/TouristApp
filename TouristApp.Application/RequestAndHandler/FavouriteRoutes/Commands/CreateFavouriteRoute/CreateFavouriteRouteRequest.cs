using MediatR;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.CreateFavouriteRoute;

public record CreateFavouriteRouteRequest(Guid UserId, Guid RouteId) : IRequest<(Guid, Guid)>;