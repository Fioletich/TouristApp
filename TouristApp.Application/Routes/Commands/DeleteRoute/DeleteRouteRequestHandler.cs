using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.Routes.Commands.DeleteRoute;

public class DeleteRouteRequestHandler : IRequestHandler<DeleteRouteRequest> {
    private ITouristApplicationDbContext _context;

    public DeleteRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeleteRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Routes), request.Id);
        }

        _context.Routes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}