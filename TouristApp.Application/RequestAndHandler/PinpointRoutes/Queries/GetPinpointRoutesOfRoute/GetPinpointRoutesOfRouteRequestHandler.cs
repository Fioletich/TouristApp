using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoutesOfRoute;

public class GetPinpointRoutesOfRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<GetPinpointRoutesOfRouteRequest, IEnumerable<PinpointRoute>> {

    public async Task<IEnumerable<PinpointRoute>> Handle(GetPinpointRoutesOfRouteRequest request, CancellationToken cancellationToken) {
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);
        
        return context.PinpointRoutes.Where(pr => pr.RouteId == request.RouteId).AsEnumerable();
    }
}