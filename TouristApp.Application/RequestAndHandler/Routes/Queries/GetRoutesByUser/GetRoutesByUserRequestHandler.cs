using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByUser;

public class GetRoutesByUserRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetRoutesByUserRequest, IEnumerable<Route>> {

    public async Task<IEnumerable<Route>> Handle(GetRoutesByUserRequest request, CancellationToken cancellationToken) {
        var routes = await context.Routes
            .Where(r => r.UserId == request.UserId)
            .ToListAsync(cancellationToken: cancellationToken);

        return routes;
    }
}