using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetFavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.DeleteFavouritePinpoint;

public class DeleteFavouritePinpointRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<DeleteFavouritePinpointRequest>{

    public async Task Handle(DeleteFavouritePinpointRequest request, CancellationToken cancellationToken) {
        var favouriteRoute = await mediator
            .Send(new GetFavouritePinpointRequest(request.UserId, request.PinpointId), cancellationToken);
        
        context.FavouritePinpoints.Remove(favouriteRoute);
        await context.SaveChangesAsync(cancellationToken);
    }
}