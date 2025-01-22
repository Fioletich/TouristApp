using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<DeleteTouristRouteRequest> {

    public async Task Handle(DeleteTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || request.Id != entity.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }

        context.TouristRoutes.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}