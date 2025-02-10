using System.Globalization;
using System.Text.Json;
using Microsoft.JSInterop;
using TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetAllCategories;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.Coordinate;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Domain.Models.Route;
using TouristApp.Web.Utils;

namespace TouristApp.Web.Components.Pages.Search;

public partial class RouteSearchForm {
    private string _firstPinpointToBuild = string.Empty;
    
    private RouteDto _searchedRoute = new RouteDto()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Description = string.Empty
    };

    private IEnumerable<CategoryOfPinpointDto> _categories = [];
    private CategoryOfPinpointDto _searchedCategoryOfPinpoint = new CategoryOfPinpointDto()
    {
        Id = Guid.Empty,
        Name = string.Empty,
        Description = string.Empty
    };

    private IEnumerable<RouteDto> _suggestedRoutes = [];
    
    private bool _isDataLoaded;
    private bool _isDisposed;
    private bool _isGeoSelected;

    private Coordinate _geoCoordinates;

    async protected override Task OnInitializedAsync() {
        _categories = (await Mediator.Send(new GetAllCategoriesOfPinpointRequest()))
            .Select(Mapper.Map<CategoryOfPinpointDto>);

        _suggestedRoutes = (await Mediator.Send(new GetAllRoutesRequest()))
            .Select(Mapper.Map<RouteDto>);

        _isDataLoaded = true;
    }

    async protected override Task OnAfterRenderAsync(bool firstRender) {
        if (firstRender)
        {
            try
            {
                await Task.Delay(1000);
                await Js.InvokeVoidAsync("initSearchMap");
            }
            catch (OperationCanceledException)
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

    private async Task BuildRouteHandler() {
        var route = _suggestedRoutes
            .FirstOrDefault(r => r.Name == _searchedRoute.Name);

        if (route is not null)
        {
            if (_firstPinpointToBuild != string.Empty)
            {
                await BuildRoute(route.Id, _firstPinpointToBuild);

                return;
            }

            await BuildRoute(route.Id);
        }
    }
    
    private async Task BuildRoute(Guid routeId , string? firstPinpoint = null) {
        var route = Mapper.Map<RouteDto>(await Mediator.Send(new GetRouteRequest(routeId)));

        var pinpointRoutes = (await Mediator.Send(new GetAllPinpointRoutesRequest()))
            .Select(Mapper.Map<PinpointRouteDto>)
            .Where(tr => tr.RouteId == route.Id);

        
        var enumerable = pinpointRoutes as PinpointRouteDto[] ?? pinpointRoutes.ToArray();

        if (enumerable.Count() < 2)
        {
            return;
        }
        
        var pinPoints = new List<JsPinpoint>();

        if (firstPinpoint is not null && !_isGeoSelected)
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

        if (firstPinpoint is null && _isGeoSelected)
        {
            var firstPinpointGeo = new JsPinpoint
            {
                Images = new[] { "" },
                Info = "Начальная точка, определенная геолокацией",
                Coords = new decimal[2]
            };

            GeoLocationBroker.CoordinatesChanged += async coordinate =>
            {
                firstPinpointGeo.Coords[1] = coordinate.Longitude;
                firstPinpointGeo.Coords[0] = coordinate.Latitude;
                    
                pinPoints.Add(firstPinpointGeo);
                    
                foreach (var pinpointRoute in enumerable)
                {
                    var pinpoint = Mapper.Map<PinpointDto>
                        (await Mediator.Send(new GetPinpointRequest(pinpointRoute.PinpointId)));

                    if (pinpoint != null)
                    {
                        var jsPinpoint = pinpoint.ConvertToJsPinpoint();

                        if (!string.IsNullOrEmpty(pinpoint.AudioUrl))
                        {
                            jsPinpoint.Info += "<p><audio controls=\"controls\">      " +
                                               $"     <source src=\"{pinpoint.AudioUrl}\" type=\"audio/mp3\"></audio></p>";
                        
                        }
                    
                        pinPoints.Add(jsPinpoint);
                    }

                }

                pinPoints = pinPoints.ToArray().OrderByCoords().ToList();
        
                await Js.InvokeVoidAsync("buildSearchMapRoute", JsonSerializer.Serialize(pinPoints));
            };
            
            await GeoLocationBroker.RequestGeoLocationAsync(true, 60000);
            return;
        }
        
        foreach (var touristRoute in enumerable)
        {
            var pinpoint = Mapper.Map<PinpointDto>(await Mediator.Send(new GetPinpointRequest(touristRoute.PinpointId)));

            if (pinpoint != null)
            {
                var jsPinpoint = pinpoint.ConvertToJsPinpoint();

                if (!string.IsNullOrEmpty(pinpoint.AudioUrl))
                {
                    jsPinpoint.Info += "<p><audio controls=\"controls\">      " +
                                       $"     <source src=\"{pinpoint.AudioUrl}\" type=\"audio/mp3\"></audio></p>";
                }
            
                pinPoints.Add(jsPinpoint);
            }

        }

        pinPoints = pinPoints.ToArray().OrderByCoords().ToList();

        await Js.InvokeVoidAsync("buildSearchMapRoute", JsonSerializer.Serialize(pinPoints));
    }
}