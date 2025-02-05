using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetFavouriteRoute;

public class GetFavouriteRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetFavouriteRouteRequest, FavouriteRoute> {

    public async Task<FavouriteRoute> Handle(GetFavouriteRouteRequest request, CancellationToken cancellationToken) {
        var favouriteRoute = await context.FavouriteRoutes
            .FirstOrDefaultAsync(fr => fr.RouteId == request.RouteId 
                                       && fr.RouteId == request.RouteId, cancellationToken);

        if (favouriteRoute is null || favouriteRoute.RouteId != request.RouteId
                                    || favouriteRoute.UserId != request.UserId)
        {
            throw new NotFoundException("Favourite route not found", request.RouteId);
        }

        return favouriteRoute;
    }
}