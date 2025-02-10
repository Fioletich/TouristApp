using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Pinpoints.PinpointsComponents;

public partial class ListOfRoutes : ComponentBase {
    [Parameter] 
    [EditorRequired] 
    public IEnumerable<RouteDto> Routes { get; set; } = [];
    
    private async Task<GridDataProviderResult<RouteDto>> RoutesDataProvider(GridDataProviderRequest<RouteDto> request) {
        return await Task.FromResult(request.ApplyTo(Routes));
    }
}