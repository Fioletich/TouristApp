using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;

public class GetPinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetPinpointRequest, Pinpoint> {

    public async Task<Pinpoint> Handle(GetPinpointRequest request, CancellationToken cancellationToken) {
        var pinpoint = await context.Pinpoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (pinpoint is null)
        {
            throw new NotFoundException("Pinpoint", request.Id);
        }

        return pinpoint;
    }
}