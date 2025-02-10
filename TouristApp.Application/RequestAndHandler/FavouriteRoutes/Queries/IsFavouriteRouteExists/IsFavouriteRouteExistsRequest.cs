using MediatR;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.IsFavouriteRouteExists;

public record IsFavouriteRouteExistsRequest(Guid UserId, Guid RouteId) : IRequest<bool>;