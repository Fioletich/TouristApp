using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.JsonWebTokens;
using TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Forms.RouteCreationForms;

public partial class RouteCreationForm : ComponentBase {
    [Inject] public IMediator Mediator { get; set; } = default!;
    
    [CascadingParameter] public Task<AuthenticationState> AuthTask { get; set; } = default!;
    
    private RouteDto _route = new RouteDto();
    private Guid _userId;
    private EditContext? _editContext;

    async protected override Task OnInitializedAsync() {
        var user = (await AuthTask).User;
        _userId = Guid.Parse(user.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value);
        
        _editContext = new EditContext(_route);
        
        await base.OnInitializedAsync();
    }

    private async Task HandleValidSubmit() {
        if (_editContext!.Validate())
        {
            await Mediator.Send(new CreateRouteRequest(
                Name: _route.Name,
                Description: _route.Description,
                UserId: _userId
            ));
            
            _route = new RouteDto();
            _editContext = new EditContext(_route);
        }
    }

    private void ResetForm() {
        _route = new RouteDto();
        _editContext = new EditContext(_route);
    }
}