using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequestHandler : IRequestHandler<CreateTouristRouteRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateTouristRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator) {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTouristRouteRequest request, CancellationToken cancellationToken) {
        var pinPoint = await _context.PinPoints
            .FirstOrDefaultAsync(p => request.PinPointId == p.Id, cancellationToken);

        var route = await _context.Routes
            .FirstOrDefaultAsync(t => request.RouteId == t.Id, cancellationToken);

        if (pinPoint is null || pinPoint.Id != request.PinPointId )
        {
            throw new NotFoundException(nameof(PinPoint), request.PinPointId);
        }

        if (route is null || route.Id != request.RouteId)
        {
            throw new NotFoundException(nameof(Route), request.RouteId);
        }
        
        var entity = new TouristRoute()
        {
            Id = Guid.NewGuid(),
            PinPointId = request.PinPointId,
            RouteId = request.RouteId
        };

        await _context.TouristRoutes.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}