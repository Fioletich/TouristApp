using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.FavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetFavouritePinpoint;

public class GetFavouritePinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetFavouritePinpointRequest, FavouritePinpoint> {

    public async Task<FavouritePinpoint> Handle(GetFavouritePinpointRequest request, CancellationToken cancellationToken) {
        var favouritePinpoint = await context.FavouritePinpoints
            .FirstOrDefaultAsync(fp => fp.UserId == request.UserId
                && fp.PinpointId == request.PinpointId, cancellationToken);

        if (favouritePinpoint is null || favouritePinpoint.UserId != request.UserId ||
            favouritePinpoint.PinpointId != request.PinpointId)
        {
            throw new NotFoundException(nameof(FavouritePinpoint), request.PinpointId);
        }
        
        return favouritePinpoint;
    }
}