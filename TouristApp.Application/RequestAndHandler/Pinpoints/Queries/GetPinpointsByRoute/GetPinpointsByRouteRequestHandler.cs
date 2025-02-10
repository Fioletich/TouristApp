using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinpointsByRoute;

public class GetPinpointsByRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<GetPinpointsByRouteRequest, IEnumerable<Pinpoint>> {

    public async Task<IEnumerable<Pinpoint>> Handle(GetPinpointsByRouteRequest request, CancellationToken cancellationToken) {
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);

        var pinpointRoutes = context.PinpointRoutes
            .Where(pr => pr.RouteId == request.RouteId)
            .AsEnumerable();
        
        var pinpoints = new List<Pinpoint>();

        foreach (var pinpointRoute in pinpointRoutes)
        {
            pinpoints.Add(await mediator.Send(new GetPinpointRequest(pinpointRoute.PinpointId), cancellationToken));
        }
        
        return pinpoints;
    }
}