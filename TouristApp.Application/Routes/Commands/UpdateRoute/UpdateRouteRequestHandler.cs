using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Routes.Commands.UpdateRoute;

public class UpdateRouteRequestHandler : IRequestHandler<UpdateRouteRequest> {
    private ITouristApplicationDbContext _context;

    public UpdateRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task Handle(UpdateRouteRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Routes
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id) {
            throw new NotFoundException(nameof(Route), request.Id);
        }

        entity.Description = request.Description;
        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}