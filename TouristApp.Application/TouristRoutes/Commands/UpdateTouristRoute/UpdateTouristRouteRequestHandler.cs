using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Commands.UpdateTouristRoute;

public class UpdateTouristRouteRequestHandler : IRequestHandler<UpdateTouristRouteRequest> {
    private readonly ITouristApplicationDbContext _context;

    public UpdateTouristRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(UpdateTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }

        entity.RouteId = request.RouteId;
        entity.PinPointId = request.PinPointId;

        await _context.SaveChangesAsync(cancellationToken);
    }
}