using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;

public class GetAllFavouriteRoutesRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllFavouriteRouteRequest, IEnumerable<FavouriteRoute>> {

    public async Task<IEnumerable<FavouriteRoute>> Handle(GetAllFavouriteRouteRequest request, CancellationToken cancellationToken) {
        return await context.FavouriteRoutes.ToListAsync(cancellationToken);
    }
}