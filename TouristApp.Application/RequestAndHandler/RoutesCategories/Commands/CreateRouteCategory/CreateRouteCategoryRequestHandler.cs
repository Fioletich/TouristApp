using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.CreateRouteCategory;

public class CreateRouteCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreateRouteCategoryRequest> {

    public async Task Handle(CreateRouteCategoryRequest request, CancellationToken cancellationToken) {
        var routeCategory = RouteCategory.Create(request.RouteId, request.CategoryOfRouteId);
        
        routeCategory.Update();
        
        await context.RouteCategories.AddAsync(routeCategory, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}