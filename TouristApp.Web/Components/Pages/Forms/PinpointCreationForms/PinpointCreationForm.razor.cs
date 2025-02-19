using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Components.Pages.Forms.PinpointCreationForms;

public partial class PinpointCreationForm : ComponentBase {
    [Inject] public IMediator Mediator { get; set; } = default!;
    
    private PinpointDto _pinpoint = new PinpointDto();
    private EditContext? _pinpointEditContext;

    async protected override Task OnInitializedAsync() {
        _pinpointEditContext = new EditContext(_pinpoint);
        
        await base.OnInitializedAsync();
    }

    private async Task HandleValidSubmit() {
        if (_pinpointEditContext!.Validate())
        {
            await Mediator.Send(new CreatePinpointRequest(
                Name: _pinpoint.Name,
                Description: _pinpoint.Description,
                AudioUrl: _pinpoint.AudioUrl,
                XCoordinate: _pinpoint.XCoordinate,
                YCoordinate: _pinpoint.YCoordinate
            ));
            
            _pinpoint = new PinpointDto();
            _pinpointEditContext = new EditContext(_pinpoint);
        }
    }

    private void ResetForm() {
        _pinpoint = new PinpointDto();
        _pinpointEditContext = new EditContext(_pinpoint);
    }
}