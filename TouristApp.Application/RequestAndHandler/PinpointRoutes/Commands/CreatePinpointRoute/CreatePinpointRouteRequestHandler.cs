using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.CreatePinpointRoute;

public class CreatePinpointRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<CreatePinpointRouteRequest> {
    public async Task Handle(CreatePinpointRouteRequest request, CancellationToken cancellationToken) {
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);
        var pinpoint = await mediator.Send(new GetPinpointRequest(request.PinpointId), cancellationToken);
        
        var pinpointRoute = PinpointRoute.Create(route.Id, pinpoint.Id);
        
        await context.PinpointRoutes.AddAsync(pinpointRoute, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}