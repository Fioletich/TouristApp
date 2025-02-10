using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Components.Pages.Routes.RoutesComponents;

public partial class ListOfPinpoints : ComponentBase {
    [Parameter]
    [EditorRequired]
    public IEnumerable<PinpointDto> Pinpoints { get; set; } = [];

    private async Task<GridDataProviderResult<PinpointDto>> PinpointsDataProvider(GridDataProviderRequest<PinpointDto> request) {
        return await Task.FromResult(request.ApplyTo(Pinpoints));
    }
}