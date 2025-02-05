using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;

public class DeletePinpointRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeletePinpointRequest> {
    public async Task Handle(DeletePinpointRequest request, CancellationToken cancellationToken) {
        var pinpoint = await context.Pinpoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        if (pinpoint is null || pinpoint.Id != request.Id)
        {
            throw new NotFoundException(nameof(Pinpoints), request.Id);
        }

        context.Pinpoints.Remove(pinpoint);

        await context.SaveChangesAsync(cancellationToken);
    }
}