using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetAllRouteCategories;

public class GetAllRouteCategoriesRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetAllRouteCategoriesRequest, IEnumerable<RouteCategory>> {

    public async Task<IEnumerable<RouteCategory>> Handle(GetAllRouteCategoriesRequest request, CancellationToken cancellationToken) {
        return await context.RouteCategories.ToListAsync(cancellationToken);
    }
}