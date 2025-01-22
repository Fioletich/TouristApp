using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<CreateTouristRouteRequest, Guid> {
    private readonly IMediator _mediator = mediator;
    public async Task<Guid> Handle(CreateTouristRouteRequest request, CancellationToken cancellationToken) {
        var pinPoint = await context.Pinpoints
            .FirstOrDefaultAsync(p => request.PinPointId == p.Id, cancellationToken);

        var route = await context.Routes
            .FirstOrDefaultAsync(t => request.RouteId == t.Id, cancellationToken);

        if (pinPoint is null || pinPoint.Id != request.PinPointId )
        {
            throw new NotFoundException(nameof(Pinpoint), request.PinPointId);
        }

        if (route is null || route.Id != request.RouteId)
        {
            throw new NotFoundException(nameof(Route), request.RouteId);
        }
        
        var entity = new TouristRoute()
        {
            Id = Guid.NewGuid(),
            PinpointId = request.PinPointId,
            RouteId = request.RouteId
        };

        await context.TouristRoutes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}