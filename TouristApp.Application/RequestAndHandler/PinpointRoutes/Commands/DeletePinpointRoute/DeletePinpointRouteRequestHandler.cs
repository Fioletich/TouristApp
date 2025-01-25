using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;

public class DeletePinpointRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<DeletePinpointRouteRequest>{

    public async Task Handle(DeletePinpointRouteRequest request, CancellationToken cancellationToken) {
        var pinpointRoute = await context.PinpointRoutes
            .FirstOrDefaultAsync(pr => pr.PinpointId == request.PinpointId && pr.RouteId == request.RouteId,
                cancellationToken);

        if (pinpointRoute is null)
        {
            throw new NotFoundException("PinpointRoute", request.RouteId);
        }
        
        context.PinpointRoutes.Remove(pinpointRoute);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}