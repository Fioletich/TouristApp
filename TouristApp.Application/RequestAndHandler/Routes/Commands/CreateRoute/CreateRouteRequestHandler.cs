using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;

public class CreateRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<CreateRouteRequest, Guid> {
    public async Task<Guid> Handle(CreateRouteRequest request, CancellationToken cancellationToken) {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null || user.Id != request.UserId)
        {
            throw new NotFoundException("User", request.UserId);
        }
        
        var route = Route.Create(user, request.Name, request.Description);

        await context.Routes.AddAsync(route, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return route.Id;
    }
}