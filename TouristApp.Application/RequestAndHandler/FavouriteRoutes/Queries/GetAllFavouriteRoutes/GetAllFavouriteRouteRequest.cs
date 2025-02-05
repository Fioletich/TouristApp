using MediatR;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;

public record GetAllFavouriteRouteRequest() : IRequest<IEnumerable<FavouriteRoute>>;