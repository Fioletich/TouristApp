using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRouteByPinpoint;

public class GetRoutesByPinpointRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<GetRoutesByPinpointRequest, IEnumerable<Route>> {

    public async Task<IEnumerable<Route>> Handle(GetRoutesByPinpointRequest request, CancellationToken cancellationToken) {
        var pinpoint = await mediator.Send(new GetPinpointRequest(request.pinpointId), cancellationToken);

        var pinpointRoutes = context.PinpointRoutes
            .Where(pr => pr.PinpointId == request.pinpointId)
            .AsEnumerable();
        
        var routes = new List<Route>();

        foreach (var pinpointRoute in pinpointRoutes)
        {
            routes.Add(await mediator.Send(new GetRouteRequest(pinpointRoute.RouteId), cancellationToken));
        }
        
        return routes;
    }
}