using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Routes.Queries.GetRoute;

public class GetRouteRequestHandler : IRequestHandler<GetRouteRequest, Route> {
    private readonly ITouristApplicationDbContext _context;

    public GetRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Route> Handle(GetRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        return entity;
    }
}