using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;

public class UpdatePinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<UpdatePinpointRequest, Unit> {
    public async Task<Unit> Handle(UpdatePinpointRequest request, CancellationToken cancellationToken) {
        var entity = await context.Pinpoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Pinpoints), request.Id);
        }
        
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.AudioUrl = request.AudioUrl;
        entity.XCoordinate = request.XCoordinate;
        entity.YCoordinate = request.YCoordinate;

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}