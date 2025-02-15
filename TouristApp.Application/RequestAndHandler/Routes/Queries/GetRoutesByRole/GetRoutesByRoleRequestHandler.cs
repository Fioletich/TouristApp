using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByRole;

public class GetRoutesByRoleRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<GetRoutesByRoleRequest, IEnumerable<Route>> {

    public async Task<IEnumerable<Route>> Handle(GetRoutesByRoleRequest request, CancellationToken cancellationToken) {
        var routes = new List<Route>();

        foreach (var route in context.Routes)
        {
            if ((await mediator.Send(new GetUserRequest(route.UserId), cancellationToken)).Role.Id == request.roleId) 
                routes.Add(route);
        }

        return routes;
    }
}