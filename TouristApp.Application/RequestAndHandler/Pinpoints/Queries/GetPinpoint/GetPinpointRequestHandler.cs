using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;

public class GetPinpointRequestHandler : IRequestHandler<GetPinpointRequest, Pinpoint> {
    private readonly ITouristApplicationDbContext _context;
    
    public GetPinpointRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<Pinpoint> Handle(GetPinpointRequest request, CancellationToken cancellationToken) {
        var result = await _context.Pinpoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (result is null)
        {
            throw new NotFoundException("PinPoint", request.Id);
        }

        return result;
    }
}