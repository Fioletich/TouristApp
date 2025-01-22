using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Queries.GetAllTouristRoutes;

public class GetAllTouristRoutesRequestHandler(ITouristApplicationDbContext context) :
    IRequestHandler<GetAllTouristRoutesRequest, IEnumerable<TouristRoute>> {
    public async Task<IEnumerable<TouristRoute>> Handle(GetAllTouristRoutesRequest request, CancellationToken cancellationToken) {
        return await context.TouristRoutes.ToListAsync(cancellationToken);
    }
}