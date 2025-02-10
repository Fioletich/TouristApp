using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinpointsByRoute;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Routes.RoutesComponents;

public partial class Route : ComponentBase {
    [Parameter]
    [EditorRequired]
    public IEnumerable<RouteDto> Routes { get; set; } = default!;
    
    [Parameter]
    [EditorRequired]
    public IEnumerable<FavouriteRouteDto> FavouriteRoutes { get; set; } = default!;
    
    [Parameter]
    [EditorRequired]
    public Guid UserId { get; set; }
    
    [Parameter]
    [EditorRequired]
    public bool IsUserCreatedRoutes { get; set; }
    
    [Parameter]
    [EditorRequired]
    public string Title { get; set; } = default!;
    
    private string? _routeName;
    private Guid _categoryIdForSearch;
    
    private Modal _routeDescriptionModal = null!;
    private Modal _routePinpointsModal = null!;

    private bool _isOnlyFavouriteRoutes;
    
    private async Task OnRoutePinpointsModalClicked(RouteDto route) {
        var parameters = new Dictionary<string, object>();

        var pinpoints = (await Mediator.Send(new GetPinpointsByRouteRequest(route.Id)))
            .Select(Mapper.Map<PinpointDto>);
        
        parameters.Add("Pinpoints", pinpoints);
        
        await _routePinpointsModal
            .ShowAsync<ListOfPinpoints>("Точки туристического маршрута", parameters: parameters);
    }

    private async Task OnRouteDescriptionModalClicked(RouteDto route) {
        _routeDescriptionModal.Message = route.Description;
        await _routeDescriptionModal.ShowAsync();
    }

    private async Task OnRouteDeleteEventCallback(RouteDto route) {
        Routes = Routes.Where(r => r.Id != route.Id).ToList();
        FavouriteRoutes = (await Mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(Mapper.Map<FavouriteRouteDto>);
    }
    
    private async Task OnFavouriteRouteDeleteEventCallback(RouteDto route) {
        FavouriteRoutes = (await Mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(Mapper.Map<FavouriteRouteDto>);
    }
    
    private async Task OnFavouriteRouteAddEventCallback(FavouriteRouteDto route) {
        FavouriteRoutes = (await Mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(Mapper.Map<FavouriteRouteDto>);
    }
    
    private async Task OnSwitchClick() {
        if (!_isOnlyFavouriteRoutes)
        {
            Routes = Routes.Where(r => 
                FavouriteRoutes.Any(fr => fr.RouteId == r.Id));
        }
        else
        {
            Routes = (await Mediator.Send(new GetAllRoutesRequest()))
                .Select(Mapper.Map<RouteDto>);
        }
    }
}