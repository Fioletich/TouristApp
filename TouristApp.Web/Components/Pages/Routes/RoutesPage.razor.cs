using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetAllCategoriesOfRoutes;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;
using TouristApp.Application.RequestAndHandler.Roles.Queries.GetRoleByName;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByRole;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByUser;
using TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetAllRouteCategories;
using TouristApp.Domain.Models.CategoryOfRoute;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Web.Components.Pages.Routes;

public partial class RoutesPage : ComponentBase {
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; } = default!;
    private ClaimsPrincipal _user = default!;
    private Guid _userId;
    
    private IEnumerable<RouteDto> _verifiedRoutes = [];
    private IEnumerable<RouteDto> _routesOfUser = [];
    private IEnumerable<FavouriteRouteDto> _favouriteRoutes = [];
    private IEnumerable<CategoryOfRouteDto> _categoryOfRoutes = [];
    private IEnumerable<RouteCategoryDto> _routeCategories = [];
    
    
    async protected override Task OnInitializedAsync() {
        _verifiedRoutes = (await Mediator.Send(new GetRoutesByRoleRequest(
                (await Mediator.Send(new GetRoleByNameRequest("Admin"))).Id)))
            .Select(Mapper.Map<RouteDto>);
        
        _user = (await AuthTask).User;

        _userId = Guid.Parse(_user.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value);

        _routesOfUser = (await Mediator.Send(new GetRoutesByUserRequest(_userId)))
            .Select(Mapper.Map<RouteDto>);
        
        _favouriteRoutes = (await Mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(Mapper.Map<FavouriteRouteDto>);
        
        _categoryOfRoutes = (await Mediator.Send(new GetAllCategoriesOfRoutes()))
            .Select(Mapper.Map<CategoryOfRouteDto>);
        
        _routeCategories = (await Mediator.Send(new GetAllRouteCategoriesRequest()))
            .Select(Mapper.Map<RouteCategoryDto>);
    }
}