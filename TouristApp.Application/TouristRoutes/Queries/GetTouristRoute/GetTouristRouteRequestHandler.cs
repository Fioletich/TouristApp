using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Queries.GetTouristRoute;

public class GetTouristRouteRequestHandler : IRequestHandler<GetTouristRouteRequest, TouristRoute> {
    private ITouristApplicationDbContext _context;

    public GetTouristRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<TouristRoute> Handle(GetTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }

        return entity;
    }
}