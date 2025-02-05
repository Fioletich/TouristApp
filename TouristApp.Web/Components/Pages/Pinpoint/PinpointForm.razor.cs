using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.Pinpoint;
using TouristApp.Domain.Models.PinpointRoute;
using TouristApp.Web.Utils;

namespace TouristApp.Web.Components.Pages.Pinpoint;

public partial class PinpointForm : ComponentBase {
    private PinpointDto _pinpoint = new PinpointDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };

    private string _coordinates = string.Empty;

    private IEnumerable<CategoryDto> _categoriesOfSelected = [];
    private IEnumerable<CategoryDto> _categories = [];
    private CategoryDto _category = new CategoryDto()
    {
        Name = string.Empty,
        Description = string.Empty
    };

    private Guid _categoryIdForDeletion;
    private Guid _categoryIdForAdd;

    private IEnumerable<PinpointDto> _pinpoints = [];

    private IEnumerable<PinpointRouteDto> _pinpointRoutes = [];

    private bool _isPinpointSelected;
    private bool _isDataLoaded;
    private bool _isDisposed;

    async protected override Task OnInitializedAsync() {
        _categories = (await Mediator.Send(new GetAllCategoriesRequest()))
            .Select(Mapper.Map<CategoryDto>);
        
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
                await Js.InvokeVoidAsync("initPinpointMap");
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

    private async Task PinpointSelected() {
        if (_pinpoint.Id != Guid.Empty)
        {
            var idPinpoint = Mapper.Map<PinpointDto>(await Mediator.Send(new GetPinpointRequest(_pinpoint.Id)));

            if (idPinpoint != null)
            {
                var pinpoint = new PinpointDto()
                {
                    Name = idPinpoint.Name,
                    Description = idPinpoint.Description,
                    XCoordinate = idPinpoint.XCoordinate,
                    YCoordinate = idPinpoint.YCoordinate
                };

                await Js.InvokeVoidAsync("buildPinpointMapRoute",
                    JsonSerializer
                        .Serialize(new[] { pinpoint.ConvertToJsPinpoint() }));
            }

            _isPinpointSelected = true;

            return;
        }

        _isPinpointSelected = false;
    }

    private async Task SavePinpoint() {
        if (_pinpoint.Name != string.Empty &&
            _pinpoint.Description != string.Empty &&
            _coordinates != string.Empty)
        {
            string[] coordinates = _coordinates.Trim().Split(',');

            bool isXConverted = decimal.TryParse(coordinates[0], out decimal tempX);
            bool isYConverted = decimal.TryParse(coordinates[1], out decimal tempY);

            if (isXConverted && isYConverted)
            {
                _pinpoint.XCoordinate = tempX;
                _pinpoint.YCoordinate = tempY;
                
                //_pinpoint.Id = await Mediator.Send(new CreatePinpointRequest());
                //_pinpoint.Id = await PinpointService.Post(_pinpoint); 
            
                _pinpoint.Name = string.Empty;
                _pinpoint.Description = string.Empty;
                _pinpoint.XCoordinate = 0;
                _pinpoint.YCoordinate = 0;
            }
        }
    }

    private async Task UpdatePinpoint() {
        if (_pinpoint.Name != string.Empty &&
            _pinpoint.Description != string.Empty &&
            _pinpoint.Id != Guid.Empty &&
            _coordinates != string.Empty)
        {
            string[] coordinates = _coordinates.Trim().Split(',');

            bool isXConverted = decimal.TryParse(
                coordinates[0], NumberStyles.Any ^ NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture,
                out decimal tempX);
            bool isYConverted = decimal.TryParse(coordinates[1],
                NumberStyles.Any ^ NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture,
                out decimal tempY);

            if (isXConverted && isYConverted)
            {
                _pinpoint.XCoordinate = tempX;
                _pinpoint.YCoordinate = tempY;
                
                await Mediator.Send(new UpdatePinpointRequest(
                    _pinpoint.Id, 
                    _pinpoint.Name,
                    _pinpoint.Description,
                    _pinpoint.AudioUrl,
                    _pinpoint.XCoordinate,
                    _pinpoint.YCoordinate));

                _pinpoint.Name = string.Empty;
                _pinpoint.Description = string.Empty;
                _coordinates = string.Empty;
            }
        }
    }

    private async Task CheckPinpoint() {
        if (_pinpoint.Id != Guid.Empty)
        {
            var pinpoint = await Mediator.Send(new GetPinpointRequest(_pinpoint.Id));
            
            _pinpoint.Name = pinpoint.Name;
            _pinpoint.Description = pinpoint.Description;
            _pinpoint.AudioUrl = pinpoint.AudioUrl;

            string xCoordinate = pinpoint.XCoordinate
                .ToString(CultureInfo.InvariantCulture).Replace(',', '.');

            string yCoordinate = pinpoint.YCoordinate
                .ToString(CultureInfo.InvariantCulture).Replace(',', '.');

            _coordinates = $"{xCoordinate}, {yCoordinate}";
            
            return;
        }

        _pinpoint.Name = string.Empty;
        _pinpoint.Description = string.Empty;
        _coordinates = string.Empty;
    }

    private async Task DeletePinpoint() {
        if (_pinpoint.Id != Guid.Empty)
        {
            var trsids = _pinpointRoutes
                .Where(tr => tr.PinpointId == _pinpoint.Id)
                .Select(tr => (tr.PinpointId, tr.RouteId));
                
            foreach (var id in trsids)
            { 
                await Mediator.Send(new DeletePinpointRouteRequest(id.RouteId, id.PinpointId));
            }
            
            await Mediator.Send(new DeletePinpointRequest(_pinpoint.Id));
        }
    }
}