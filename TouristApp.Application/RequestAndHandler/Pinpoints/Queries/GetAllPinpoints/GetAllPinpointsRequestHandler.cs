using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;

public class GetAllPinpointsRequestHandler : IRequestHandler<GetAllPinpointsRequest, IEnumerable<Pinpoint>> {
    private readonly ITouristApplicationDbContext _context;
    
    public GetAllPinpointsRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<IEnumerable<Pinpoint>> Handle(GetAllPinpointsRequest request, CancellationToken cancellationToken) {
        return await _context.Pinpoints.ToListAsync(cancellationToken);
    }
}