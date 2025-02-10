using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.DeleteFavouriteRoute;

public class DeleteFavouriteRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<DeleteFavouriteRouteRequest> {

    public async Task Handle(DeleteFavouriteRouteRequest request, CancellationToken cancellationToken) {
        var favouriteRoute = await context.FavouriteRoutes
            .FirstOrDefaultAsync(fr => fr.RouteId == request.RouteId 
                                       && fr.UserId == request.UserId, cancellationToken);

        if (favouriteRoute is null || favouriteRoute.RouteId != request.RouteId
                                    || favouriteRoute.UserId != request.UserId)
        {
            throw new NotFoundException("Favourite route not found", request.RouteId);
        }
        
        context.FavouriteRoutes.Remove(favouriteRoute);
        await context.SaveChangesAsync(cancellationToken);
    }
}