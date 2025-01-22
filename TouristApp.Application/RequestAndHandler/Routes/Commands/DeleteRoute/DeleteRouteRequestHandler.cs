using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;

public class DeleteRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeleteRouteRequest> {
    public async Task Handle(DeleteRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Routes), request.Id);
        }

        context.Routes.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}