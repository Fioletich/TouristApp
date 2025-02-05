using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.CreateFavouriteRoute;

public class CreateFavouriteRoiuteRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<CreateFavouriteRouteRequest, (Guid, Guid)> {

    public async Task<(Guid, Guid)> Handle(CreateFavouriteRouteRequest request, CancellationToken cancellationToken) {
        var user = await mediator.Send(new GetUserRequest(request.UserId), cancellationToken);
        var route = await mediator.Send(new GetRouteRequest(request.RouteId), cancellationToken);
        
        var favouriteRoute = FavouriteRoute.Create(request.UserId, request.RouteId);
        
        await context.FavouriteRoutes.AddAsync(favouriteRoute, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        return (favouriteRoute.UserId, favouriteRoute.RouteId);
    }
}