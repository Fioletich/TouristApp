using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Routes.Queries.GetAllRoutes;

public class GetAllRoutesRequestHandler : IRequestHandler<GetAllRoutesRequest, IEnumerable<Route>> {
    private readonly ITouristApplicationDbContext _context;

    public GetAllRoutesRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Route>> Handle(GetAllRoutesRequest request, CancellationToken cancellationToken) {
        return await _context.Routes.ToListAsync(cancellationToken);
    }
}