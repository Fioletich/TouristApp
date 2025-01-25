using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;

public class GetAllPinpointRoutesRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetAllPinpointRoutesRequest, IEnumerable<PinpointRoute>> {

    public async Task<IEnumerable<PinpointRoute>> Handle(GetAllPinpointRoutesRequest request, CancellationToken cancellationToken) {
        return await context.PinpointRoutes.ToListAsync(cancellationToken);
    }
}