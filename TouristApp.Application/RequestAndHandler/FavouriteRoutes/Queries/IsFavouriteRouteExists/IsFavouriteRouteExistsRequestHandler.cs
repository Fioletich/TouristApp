using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.IsFavouriteRouteExists;

public class IsFavouriteRouteExistsRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<IsFavouriteRouteExistsRequest, bool> {

    public async Task<bool> Handle(IsFavouriteRouteExistsRequest request, CancellationToken cancellationToken) {
        var route = await context.FavouriteRoutes
            .FirstOrDefaultAsync(fr => fr.RouteId == request.RouteId 
                                       && fr.UserId == request.UserId, cancellationToken);
        
        return route is not null;
    }
}