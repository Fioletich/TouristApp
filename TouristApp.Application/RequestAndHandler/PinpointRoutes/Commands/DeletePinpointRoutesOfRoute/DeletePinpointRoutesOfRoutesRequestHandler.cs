using MediatR;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoutesOfRoute;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoutesOfRoute;

public class DeletePinpointRoutesOfRoutesRequestHandler(IMediator mediator) 
    : IRequestHandler<DeletePinpointRoutesOfRouteRequest> {

    public async Task Handle(DeletePinpointRoutesOfRouteRequest request, CancellationToken cancellationToken) {
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);
        
        var pinpointRoutes = 
            await mediator.Send(new GetPinpointRoutesOfRouteRequest(request.RouteId), cancellationToken);

        foreach (var pinpointRoute in pinpointRoutes)
        {
            await mediator.Send(
                new DeletePinpointRouteRequest(pinpointRoute.RouteId, pinpointRoute.PinpointId), 
                cancellationToken);
        }
    }
}