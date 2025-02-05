using MediatR;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;

public class CreatePinpointRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<CreatePinpointRequest, Guid> {

    public async Task<Guid> Handle(CreatePinpointRequest request, CancellationToken cancellationToken) {
        var pinpoint = Pinpoint.Create(request.Name, request.Description, request.AudioUrl,
            request.XCoordinate, request.YCoordinate);

        await context.Pinpoints.AddAsync(pinpoint, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return pinpoint.Id;
    }
}