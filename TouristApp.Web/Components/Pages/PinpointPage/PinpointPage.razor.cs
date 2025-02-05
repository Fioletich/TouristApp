using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Components.Pages.PinpointPage;

public partial class PinpointPage : ComponentBase {
    private PinpointDto[] _pinpoints = [];
    
    async protected override Task OnInitializedAsync() {
        _pinpoints = (await Mediator.Send(new GetAllPinpointsRequest()))
            .Select(Mapper.Map<PinpointDto>)
            .ToArray();
    }
}