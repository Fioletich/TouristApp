using MediatR;
using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.CreateFavouritePinpoint;
using TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.DeleteFavouritePinpoint;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Components.Pages.Pinpoints.PinpointsComponents;

public partial class PinpointCard : ComponentBase {
    [Parameter]
    [EditorRequired]
    public PinpointDto Pinpoint { get; set; } = default!;
    
    [Parameter] 
    [EditorRequired]
    public Action OnPinpointDescription { get; set; } = default!;
    
    [Parameter] 
    [EditorRequired]
    public Action OnPinpointRoutes { get; set; } = default!;
    //[Parameter] [EditorRequired] public EventCallback<PinpointDto> OnDeletePinpointEventCallback { get; set; }
    [Parameter] [EditorRequired] public EventCallback<PinpointDto> OnDeleteFavouritePinpointEventCallback { get; set; }
    [Parameter] [EditorRequired] public EventCallback<FavouritePinpointDto> OnAddFavouritePinpointEventCallback { get; set; }
    [Parameter] [EditorRequired] public Guid UserId { get; set; }

    [Parameter] [EditorRequired] public IEnumerable<FavouritePinpointDto> FavouritePinpoints { get; set; } = [];
    private bool IsPinpointFavourite => FavouritePinpoints
        .Any(fp => fp.UserId == UserId && fp.PinpointId == Pinpoint.Id);
    
    private async Task OnFavouritePinpointAddClick() {
        await Mediator.Send(new CreateFavouritePinpointRequest(UserId, Pinpoint.Id));
        
        var favouriteRoute = new FavouritePinpointDto()
        {
            UserId = UserId,
            PinpointId = Pinpoint.Id
        };
        
        await OnAddFavouritePinpointEventCallback.InvokeAsync(favouriteRoute);
    }

    private async Task OnFavouritePinpointDeleteClick() {
        await Mediator.Send(new DeleteFavouritePinpointRequest(UserId, Pinpoint.Id));
        await OnDeleteFavouritePinpointEventCallback.InvokeAsync(Pinpoint);
    }
}