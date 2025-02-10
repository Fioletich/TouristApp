using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.FavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetAllFavouritePinpoints;

public class GetAllFavouritePinpointsRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllFavouritePinpointsRequest, IEnumerable<FavouritePinpoint>> {

    public async Task<IEnumerable<FavouritePinpoint>> Handle(GetAllFavouritePinpointsRequest request, CancellationToken cancellationToken) {
        return await context.FavouritePinpoints.ToListAsync(cancellationToken);
    }
}