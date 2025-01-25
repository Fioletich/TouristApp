using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;

public class GetAllRoutesRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllRoutesRequest, IEnumerable<Route>> {
    public async Task<IEnumerable<Route>> Handle(GetAllRoutesRequest request, CancellationToken cancellationToken) {
        return await context.Routes.ToListAsync(cancellationToken);
    }
}