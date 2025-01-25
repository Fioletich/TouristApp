using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

public class GetRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<GetRouteRequest, Route> {
    public async Task<Route> Handle(GetRouteRequest request, CancellationToken cancellationToken) {
        var route = await context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (route is null || route.Id != request.Id)
        {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        return route;
    }
}