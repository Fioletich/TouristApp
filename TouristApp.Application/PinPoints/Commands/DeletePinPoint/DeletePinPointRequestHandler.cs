using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.PinPoints.Commands.DeletePinPoint;

public class DeletePinPointRequestHandler : IRequestHandler<DeletePinPointRequest> {
    private readonly ITouristApplicationDbContext _context;

    public DeletePinPointRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeletePinPointRequest request, CancellationToken cancellationToken) {
        var entity = await _context.PinPoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(PinPoints), request.Id);
        }

        _context.PinPoints.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}