using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;

public class UpdatePinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<UpdatePinpointRequest> {
    public async Task Handle(UpdatePinpointRequest request, CancellationToken cancellationToken) {
        var pinpoint = await context.Pinpoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (pinpoint is null || pinpoint.Id != request.Id)
        {
            throw new NotFoundException(nameof(Pinpoints), request.Id);
        }
        
        pinpoint.Name = request.Name ?? pinpoint.Name;
        pinpoint.Description = request.Description ?? pinpoint.Description;
        pinpoint.AudioUrl = request.AudioUrl ?? pinpoint.AudioUrl;

        if (request.XCoordinate != 0.0m)
        {
            pinpoint.XCoordinate = request.XCoordinate;
        }

        if (request.YCoordinate != 0.0m)
        {
            pinpoint.YCoordinate = request.YCoordinate;
        }
        
        pinpoint.Update();

        await context.SaveChangesAsync(cancellationToken);
    }
}