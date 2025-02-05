using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.CreatePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Web.Utils;

namespace TouristApp.Web.Components.Pages.Route;

public partial class RoutesForm : ComponentBase {
    private RouteDto _route = new RouteDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };
    
    private RouteDto  _selectedRoute = new RouteDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };
    
    private RouteDto  _buildRroute = new RouteDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };
    
    private IEnumerable<RouteDto> _routes = [];

    private Guid _pinpointIdForDeletion;
    private Guid _pinpointIdForAdd;
    private Guid _pinpointIdForAudio;
    
    private PinpointDto _selectedPinpoint = new PinpointDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };
    private string _firstPinpointToBuild = string.Empty;
    private IEnumerable<PinpointDto> _pinpoints = [];
    private IEnumerable<PinpointDto> _pinpointsOfSelected = [];

    private IEnumerable<PinpointRouteDto> _pinpointRoutes = [];
    
    private bool _isDataLoaded;
    private bool _isRouteSelected;
    private bool _isDisposed;
    private bool _isAudioSelected;

    async protected override Task OnInitializedAsync() {
        _routes = (await Mediator.Send(new GetAllRoutesRequest()))
            .Select(Mapper.Map<RouteDto>);
        
        _pinpoints = (await Mediator.Send(new GetAllPinpointsRequest()))
            .Select(Mapper.Map<PinpointDto>);

        _pinpointRoutes = (await Mediator.Send(new GetAllPinpointRoutesRequest()))
            .Select(Mapper.Map<PinpointRouteDto>);
        
        _isDataLoaded = true;
    }

    async protected override Task OnAfterRenderAsync(bool firstRender) {
        if (firstRender)
        {
            try
            {
                await Task.Delay(1000);
                await Js.InvokeVoidAsync("initRouteMap");
            }
            catch (OperationCanceledException)
            {

            }
            catch (ObjectDisposedException)
            {

            }
            catch (NullReferenceException)
            {

            }
            catch (JSDisconnectedException)
            {

            }
            catch (JSException)
            {
                
            }
        }
    }

    private async Task CreateRoute() {
        if (_route.Name != string.Empty && _route.Description != string.Empty)
        {
            //await Mediator.Send(new CreateRouteRequest());
            //await RouteService.Post(_route);

            _route.Name = string.Empty;
            _route.Description = string.Empty;
        }
    }

    private async Task RouteSelected() {
        if (_route.Id != Guid.Empty)
        {
            _pinpointsOfSelected = _pinpointRoutes
                .Where(tr => tr.RouteId == _route.Id)
                .SelectMany(pc => _pinpoints!.Where(p => p.Id == pc.PinpointId));

            if (_firstPinpointToBuild != string.Empty)
            {
                await BuildRoute(_route.Id, _firstPinpointToBuild);
                return;
            }
            await BuildRoute(_route.Id);
            
            _isRouteSelected = true;
            
            return;
        }

        _isRouteSelected = false;
    }

    private async Task AddPinpoint() {
        if (_route.Id != Guid.Empty && _pinpointIdForAdd != Guid.Empty)
        {
            await Mediator.Send(new CreatePinpointRouteRequest(_route.Id, _pinpointIdForAdd));
        }
    }

    private async Task RemovePinpoint() {
        if (_route.Id != Guid.Empty && _pinpointIdForDeletion != Guid.Empty)
        {
            var pinpointRouteForDeletion = _pinpointRoutes.FirstOrDefault(tr => tr.RouteId == _route.Id
                                                                               && tr.PinpointId == _pinpointIdForDeletion);

            if (pinpointRouteForDeletion != null)
                await Mediator.Send(new DeletePinpointRouteRequest(_route.Id, _pinpointIdForDeletion));
        }
    }
    
    private async Task CheckRoute() {
        if (_route.Id != Guid.Empty)
        {
            var route = Mapper.Map<RouteDto>(await Mediator.Send(new GetRouteRequest(_route.Id)));

            if (route != null)
            {
                _route.Name = route.Name;
                _route.Description = route.Description;
            }

            return;
        }

        _route.Name = string.Empty;
        _route.Description = string.Empty;
    }
    
    private async Task CreatePinpointRoute() {
        if (_selectedRoute.Id != Guid.Empty && _selectedPinpoint.Id != Guid.Empty)
        {
            await Mediator.Send(new CreatePinpointRouteRequest(_selectedRoute.Id, _selectedPinpoint.Id));

            await BuildRoute(_selectedRoute.Id, _firstPinpointToBuild);
        }
    }
    
    private async Task BuildRoute(Guid routeId , string? firstPinpoint = null) {
        var route = Mapper.Map<RouteDto>(await Mediator.Send(new GetRouteRequest(routeId)));

        var touristRoutes = ((await Mediator.Send(new GetAllPinpointRoutesRequest()))
            .Select(Mapper.Map<PinpointRouteDto>)
            .Where(tr => tr.RouteId == route.Id));

        var enumerable = touristRoutes as PinpointRouteDto[] ?? touristRoutes.ToArray();

        if (enumerable.Count() < 2)
        {
            return;
        }
        
        var pinPoints = new List<JsPinpoint>();

        if (firstPinpoint is not null)
        {
            string[] firstPinpointCoords = _firstPinpointToBuild.Trim().Split(','); 
            var jsPinpoint = new JsPinpoint()
            {
                Coords = new[]
                { 
                    Convert.ToDecimal(firstPinpointCoords[0], CultureInfo.InvariantCulture), 
                    Convert.ToDecimal(firstPinpointCoords[1], CultureInfo.InvariantCulture)
                },
                Images = new[] { "" },
                Info = "Маршрут от первой точки"
            };
            pinPoints.Add(jsPinpoint);
        }
        
        foreach (var touristRoute in enumerable)
        {
            var pinpoint = Mapper.Map<PinpointDto>(await Mediator.Send(new GetPinpointRequest(touristRoute.PinpointId)));
            
            var jsPinpoint = pinpoint.ConvertToJsPinpoint();

            if (!string.IsNullOrEmpty(pinpoint.AudioUrl)) 
            { 
                    jsPinpoint.Info += "\n\n<audio controls=\"controls\">\n       " + 
                                     $"     <source src=\"{pinpoint.AudioUrl}\" type=\"audio/mp3\">\n        </audio>";
            }
            
            pinPoints.Add(jsPinpoint);
        }

        pinPoints = pinPoints.ToArray().OrderByCoords().ToList();
        
        await Js.InvokeVoidAsync("buildRouteMapRoute", JsonSerializer.Serialize(pinPoints));
    }
    
    private async Task UpdateRoute() {
        if (_route.Name != string.Empty &&
            _route.Description != string.Empty &&
            _route.Id != Guid.Empty)
        {
            await Mediator.Send(new UpdateRouteRequest(_route.Id, _route.Name, _route.Description));

            _route.Name = string.Empty;
            _route.Description = string.Empty;
        }

        if (_route.Id != Guid.Empty)
        {
            var route = Mapper.Map<RouteDto>(await Mediator.Send(new GetRouteRequest(_route.Id)));

            if (route != null)
            {
                _route.Name = route.Name;
                _route.Description = route.Description;
            }
        }
    }
    
    private async Task DeleteRoute() {
        if (_route.Id != Guid.Empty)
        {
            var trsids = _pinpointRoutes
                .Where(tr => tr.RouteId == _route.Id)
                .Select(tr => KeyValuePair.Create(tr.RouteId, tr.PinpointId));

            foreach (var id in trsids)
            {
                await Mediator.Send(new DeletePinpointRouteRequest(id.Key, id.Value));
            }
            
            await Mediator.Send(new DeleteRouteRequest(_route.Id));
        }
    }

    public Task AudioSelected() {
        if (_pinpointIdForAudio == Guid.Empty)
        {
            _isAudioSelected = false;

            return Task.CompletedTask;
        }

        _isAudioSelected = true;

        return Task.CompletedTask;
    }
}