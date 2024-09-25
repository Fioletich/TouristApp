using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinPoints.Queries.GetPinPoint;

public class GetPinPointRequestHandler : IRequestHandler<GetPinPointRequest, PinPoint> {
    private ITouristApplicationDbContext _context;
    
    public GetPinPointRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<PinPoint> Handle(GetPinPointRequest request, CancellationToken cancellationToken) {
        var result = await _context.PinPoints
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (result is null)
        {
            throw new NotFoundException("PinPoint", request.Id);
        }

        return result;
    }
}