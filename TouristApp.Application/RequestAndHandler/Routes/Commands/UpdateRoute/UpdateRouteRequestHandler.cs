using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;

public class UpdateRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<UpdateRouteRequest> {
    public async Task Handle(UpdateRouteRequest request, CancellationToken cancellationToken) {
        var route = await context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (route is null || route.Id != request.Id) {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        route.Description = request.Description ?? route.Description;
        route.Name = request.Name ?? route.Name;
        
        route.Update();

        await context.SaveChangesAsync(cancellationToken);
    }
}