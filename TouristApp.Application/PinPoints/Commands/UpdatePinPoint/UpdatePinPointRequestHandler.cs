using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.PinPoints.Commands.UpdatePinPoint;

public class UpdatePinPointRequestHandler : IRequestHandler<UpdatePinPointRequest, Unit> {
    private readonly ITouristApplicationDbContext _context;

    public UpdatePinPointRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdatePinPointRequest request, CancellationToken cancellationToken) {
        var entity = await _context.PinPoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(PinPoints), request.Id);
        }
        
        entity.Name = request.Name;
        entity.XCoordinate = request.XCoordinate;
        entity.YCoordinate = request.YCoordinate;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}