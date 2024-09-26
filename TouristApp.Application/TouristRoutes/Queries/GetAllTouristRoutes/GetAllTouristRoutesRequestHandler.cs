using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Queries.GetAllTouristRoutes;

public class GetAllTouristRoutesRequestHandler : 
    IRequestHandler<GetAllTouristRoutesRequest, IEnumerable<TouristRoute>> {
    private readonly ITouristApplicationDbContext _context;

    public GetAllTouristRoutesRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    public async Task<IEnumerable<TouristRoute>> Handle(GetAllTouristRoutesRequest request, CancellationToken cancellationToken) {
        return await _context.TouristRoutes.ToListAsync(cancellationToken);
    }
}