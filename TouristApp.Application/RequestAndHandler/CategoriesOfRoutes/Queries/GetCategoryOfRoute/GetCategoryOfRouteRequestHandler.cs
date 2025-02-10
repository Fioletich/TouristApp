using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;

public class GetCategoryOfRouteRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetCategoryOfRouteRequest, CategoryOfRoute> {
    
    public async Task<CategoryOfRoute> Handle(GetCategoryOfRouteRequest request, CancellationToken cancellationToken) {
        var categoryOfRoute = await context.CategoriesOfRoutes
            .FirstOrDefaultAsync(cr => cr.Id == request.Id, cancellationToken);

        if (categoryOfRoute is null || categoryOfRoute.Id != request.Id)
        {
            throw new NotFoundException(nameof(CategoryOfRoute), request.Id);
        }
        
        return categoryOfRoute;
    }
}