using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequestHandler : IRequestHandler<DeleteTouristRouteRequest> {
    private readonly ITouristApplicationDbContext _context;

    public DeleteTouristRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeleteTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (entity is null || request.Id != entity.Id) {
            throw new NotFoundException(nameof(TouristRoute), request.Id);
        }
    }
}