using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.DeleteCategoryOfRoute;

public class DeleteCategoryOfRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<DeleteCategoryOfRouteRequest> {

    public async Task Handle(DeleteCategoryOfRouteRequest request, CancellationToken cancellationToken) {
        var categoryOfRoute = await mediator.Send(new GetCategoryOfRouteRequest(request.Id), cancellationToken);
        
        context.CategoriesOfRoutes.Remove(categoryOfRoute);
        await context.SaveChangesAsync(cancellationToken);
    }
}