using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Queries.GetTouristRoute;

public class GetTouristRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetTouristRouteRequest, TouristRoute> {
    public async Task<TouristRoute> Handle(GetTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }

        return entity;
    }
}