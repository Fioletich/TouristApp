using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;

public class GetPinpointRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<GetPinpointRouteRequest, PinpointRoute> {

    public async Task<PinpointRoute> Handle(GetPinpointRouteRequest request, CancellationToken cancellationToken) {
        var pinpoint = await mediator.Send(new GetPinpointRequest(request.PinpointId), cancellationToken);
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);
        
        var pinpointRoute = await context.PinpointRoutes
            .FirstOrDefaultAsync(
                pr => pr.PinpointId == request.PinpointId && pr.RouteId == request.RouteId , cancellationToken);

        if (pinpointRoute is null || pinpointRoute.RouteId != request.RouteId
                                  || pinpointRoute.PinpointId != request.PinpointId)
        {
            throw new NotFoundException("PinpointRoute", request.RouteId);
        }
        
        return pinpointRoute;
    }
}