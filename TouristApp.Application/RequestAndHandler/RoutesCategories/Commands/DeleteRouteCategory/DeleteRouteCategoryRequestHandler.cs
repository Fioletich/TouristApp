using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetRouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.DeleteRouteCategory;

public class DeleteRouteCategoryRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<DeleteRouteCategoryRequest> {

    public async Task Handle(DeleteRouteCategoryRequest request, CancellationToken cancellationToken) {
        var routeCategory = await mediator
            .Send(new GetRouteCategoryRequest(request.RouteId, request.RouteCategoryId), cancellationToken);
        
        context.RouteCategories.Remove(routeCategory);
        await context.SaveChangesAsync(cancellationToken);
    }
}