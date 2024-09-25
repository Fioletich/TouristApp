using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinPoints.Queries.GetAllPinPoints;

public class GetAllPinPointsRequestHandler : IRequestHandler<GetAllPinPointsRequest, IEnumerable<PinPoint>> {
    private ITouristApplicationDbContext _context;
    
    public GetAllPinPointsRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<IEnumerable<PinPoint>> Handle(GetAllPinPointsRequest request, CancellationToken cancellationToken) {
        return await _context.PinPoints.ToListAsync(cancellationToken);
    }
}