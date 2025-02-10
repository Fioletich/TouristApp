using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.UpdateCategoryOfRoute;

public class UpdateCategoryOfRouteRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<UpdateCategoryOfRouteRequest> {

    public async Task Handle(UpdateCategoryOfRouteRequest request, CancellationToken cancellationToken) {
        var categoryOfRoute = await mediator.Send(new GetCategoryOfRouteRequest(request.Id), cancellationToken);

        categoryOfRoute.Name = request.Name ?? categoryOfRoute.Name;
        categoryOfRoute.Description = request.Description ?? categoryOfRoute.Description;
        categoryOfRoute.Update();
        
        await context.SaveChangesAsync(cancellationToken);
    }
}