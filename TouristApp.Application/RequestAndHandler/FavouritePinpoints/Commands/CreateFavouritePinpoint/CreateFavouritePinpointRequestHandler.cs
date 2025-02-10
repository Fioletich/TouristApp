using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.FavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.CreateFavouritePinpoint;

public class CreateFavouritePinpointRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<CreateFavouritePinpointRequest> {

    public async Task Handle(CreateFavouritePinpointRequest request, CancellationToken cancellationToken) {
        var favouritePinpoint = FavouritePinpoint.Create(request.UserId, request.PinpointId);
        
        await context.FavouritePinpoints.AddAsync(favouritePinpoint, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}