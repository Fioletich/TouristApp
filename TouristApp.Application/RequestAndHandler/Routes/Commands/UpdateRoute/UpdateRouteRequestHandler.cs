using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;

public class UpdateRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<UpdateRouteRequest> {
    public async Task Handle(UpdateRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        entity.Description = request.Description;
        entity.Name = request.Name;

        await context.SaveChangesAsync(cancellationToken);
    }
}