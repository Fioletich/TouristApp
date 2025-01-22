using MediatR;
using Microsoft.Extensions.Logging;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;

public class CreatePinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreatePinpointRequest, Guid> {

    public async Task<Guid> Handle(CreatePinpointRequest request, CancellationToken cancellationToken) {
        var entity = new Pinpoint()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            AudioUrl = request.AudioUrl,
            XCoordinate = request.XCoordinate,
            YCoordinate = request.YCoordinate
        };

        await context.Pinpoints.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return entity.Id;
    }
}