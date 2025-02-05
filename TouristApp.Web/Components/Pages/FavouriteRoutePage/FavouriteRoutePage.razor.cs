using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.FavouriteRoutePage;

public partial class FavouriteRoutePage : ComponentBase {
    private RouteDto[] _routes = [];
    private Dictionary<Guid, IEnumerable<PinpointDto>> _routesPinpoints = new();
    private bool _isLoaded;
    
    async protected override Task OnInitializedAsync() {
        _routes = (await Mediator.Send(new GetAllRoutesRequest()))
            .Select(Mapper.Map<RouteDto>)
            .ToArray();

        foreach (var route in _routes)
        {
            var allPinpoints = (await GetPinpointsByRoute(route))
                .ToArray();
            var pinpoints = new List<PinpointDto>();

            for (int i = 0; i < 4 && i < allPinpoints.Count(); i++)
            {
                pinpoints.Add(allPinpoints[i]);
            }
            
            _routesPinpoints.Add(route.Id, pinpoints);
        }
        
        _isLoaded = true;
    }

    private async Task<IEnumerable<PinpointDto>> GetPinpointsByRoute(RouteDto route) {
        var pinpointRoutes = (await Mediator.Send(new GetAllPinpointRoutesRequest()))
            .Where(pr => pr.RouteId == route.Id);

        var pinpoints = new List<PinpointDto>();
        
        foreach (var pinpointRoute in pinpointRoutes)
        {
            pinpoints.Add(Mapper
                .Map<PinpointDto>(await Mediator.Send(new GetPinpointRequest(pinpointRoute.PinpointId))));
        }
        
        return pinpoints;
    }
}