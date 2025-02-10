using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetRouteCategory;

public class GetCategoryRouteRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetRouteCategoryRequest, RouteCategory> {

    public async Task<RouteCategory> Handle(GetRouteCategoryRequest request, CancellationToken cancellationToken) {
        var routeCategory = await context.RouteCategories
            .FirstOrDefaultAsync(rc => rc.RouteId == request.RouteId 
                                       && rc.CategoryOfRouteId == request.CategoryOfRouteId, cancellationToken);

        if (routeCategory is null)
        {
            throw new NotFoundException(nameof(RouteCategory), request.RouteId);
        }
        
        return routeCategory;
    }
}