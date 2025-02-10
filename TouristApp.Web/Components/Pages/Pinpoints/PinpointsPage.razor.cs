using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetAllFavouritePinpoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Domain.Models.FavouritePinpoint;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Components.Pages.Pinpoints;

public partial class PinpointsPage : ComponentBase {
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; } = default!;
    private ClaimsPrincipal _user = default!;
    private Guid _userId;
    private IEnumerable<PinpointDto> _pinpoints = [];
    private IEnumerable<FavouritePinpointDto> _favouritePinpoints = [];
    
    async protected override Task OnInitializedAsync() {
        _pinpoints = (await Mediator.Send(new GetAllPinpointsRequest()))
            .Select(Mapper.Map<PinpointDto>);
        _user = (await AuthTask).User;
        
        _userId = Guid.Parse(_user.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value);
        
        _favouritePinpoints = (await Mediator.Send(new GetAllFavouritePinpointsRequest()))
            .Select(Mapper.Map<FavouritePinpointDto>);
    }
}