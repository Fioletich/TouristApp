using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Routes;

public partial class RoutesPage : ComponentBase {
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; } = default!;
    private ClaimsPrincipal _user = default!;
    private Guid _userId;
    
    private IEnumerable<RouteDto> _routes = [];
    private IEnumerable<RouteDto> _routesOfUser = [];
    private IEnumerable<FavouriteRouteDto> _favouriteRoutes = [];
    
    
    async protected override Task OnInitializedAsync() {
        _routes = (await Mediator.Send(new GetAllRoutesRequest()))
            .Select(Mapper.Map<RouteDto>);
        _user = (await AuthTask).User;

        _userId = Guid.Parse(_user.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value);
        
        _routesOfUser = _routes.Where(route => route.UserId == _userId);
        
        _favouriteRoutes = (await Mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(Mapper.Map<FavouriteRouteDto>);
    }
}