using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.UpdateTouristRoute;

public class UpdateTouristRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<UpdateTouristRouteRequest> {
    public async Task Handle(UpdateTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }

        entity.RouteId = request.RouteId;
        entity.PinpointId = request.PinPointId;

        await context.SaveChangesAsync(cancellationToken);
    }
}