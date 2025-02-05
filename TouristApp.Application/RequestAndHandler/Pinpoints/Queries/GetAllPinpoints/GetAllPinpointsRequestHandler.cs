using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;

public class GetAllPinpointsRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllPinpointsRequest, IEnumerable<Pinpoint>> {

    public async Task<IEnumerable<Pinpoint>> Handle(GetAllPinpointsRequest request, CancellationToken cancellationToken) {
        return await context.Pinpoints.ToListAsync(cancellationToken);
    }
}