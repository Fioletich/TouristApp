using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetAllFavouritePinpoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRouteByPinpoint;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Pinpoints.PinpointsComponents;

public partial class Pinpoint : ComponentBase {
    [Parameter] 
    [EditorRequired] 
    public IEnumerable<PinpointDto> Pinpoints { get; set; } = [];
    
    [Parameter]
    [EditorRequired]
    public IEnumerable<FavouritePinpointDto> FavouritePinpoints { get; set; } = default!;
    
    [Parameter]
    [EditorRequired]
    public Guid UserId { get; set; }

    private string _pinpointName = string.Empty;
    
    private Guid _categoryIdForSearch;

    private Modal _pinpointDescriptionModal = default!;
    private Modal _pinpointRoutesModal = default!;
    
    private bool _isOnlyFavouritePinpoints;

    private async Task OnPinpointDescriptionModalClicked(PinpointDto pinpoint) {
        _pinpointDescriptionModal.Message = pinpoint.Description;

        await _pinpointDescriptionModal.ShowAsync();
    }

    private async Task OnPinpointRoutesModalClicked(PinpointDto pinpoint) {
        var parameters = new Dictionary<string, object>();

        var pinpoints = (await Mediator.Send(new GetRoutesByPinpointRequest(pinpoint.Id)))
            .Select(Mapper.Map<RouteDto>);
        
        parameters.Add("Routes", pinpoints);
        
        await _pinpointRoutesModal
            .ShowAsync<ListOfRoutes>("Точки туристического маршрута", parameters: parameters);
    }
    
    private async Task OnFavouritePinpointDeleteEventCallback(PinpointDto route) {
        FavouritePinpoints = (await Mediator.Send(new GetAllFavouritePinpointsRequest()))
            .Select(Mapper.Map<FavouritePinpointDto>);
    }
    
    private async Task OnFavouritePinpointAddEventCallback(FavouritePinpointDto pinpoint) {
        FavouritePinpoints = (await Mediator.Send(new GetAllFavouritePinpointsRequest()))
            .Select(Mapper.Map<FavouritePinpointDto>);
    }

    private async Task OnSwitchClick() {
        if (!_isOnlyFavouritePinpoints)
        {
            Pinpoints = Pinpoints.Where(p => 
                FavouritePinpoints.Any(fp => fp.PinpointId == p.Id));
        }
        else
        {
            Pinpoints = (await Mediator.Send(new GetAllPinpointsRequest()))
                .Select(Mapper.Map<PinpointDto>);
        }
    }
}