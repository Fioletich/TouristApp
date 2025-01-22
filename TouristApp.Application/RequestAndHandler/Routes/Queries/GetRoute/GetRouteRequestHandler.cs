using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

public class GetRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<GetRouteRequest, Route> {
    public async Task<Route> Handle(GetRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        return entity;
    }
}