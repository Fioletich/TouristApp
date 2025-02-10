using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.CreateCategoryOfRoute;

public class CreateCategoryOfRouteRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreateCategoryOfRouteRequest, Guid>{

    public async Task<Guid> Handle(CreateCategoryOfRouteRequest request, CancellationToken cancellationToken) {
        var categoryOfRoute = CategoryOfRoute.Create(request.Name, request.Description);
        
        await context.CategoriesOfRoutes.AddAsync(categoryOfRoute, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return categoryOfRoute.Id;
    }
}