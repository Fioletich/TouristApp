using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;
using TouristApp.Web.Identity;

namespace TouristApp.Web.Components.Pages.AuthPage;

public partial class AuthPage : ComponentBase {
    private bool _isLoaded;
    private LoginModel _loginModel = new LoginModel();
    private IEnumerable<User> _users = [];

    async protected override Task OnInitializedAsync() {
        _users = await Mediator.Send(new GetAllUsersRequest());
        
        _isLoaded = true;
    }

    private async Task Login() {
        var user = _users.FirstOrDefault(u => u.Login == _loginModel.Login && u.Password == _loginModel.Password);

        if (user is null)
        {
            return;
        }
        
        var token = TokenGenerator.GenerateToken(user);

        await ((CustomAuthStateProvider)AuthStateProvider).AuthUser(token);
        NavManager.NavigateTo($"{NavManager.BaseUri}", true);
    }
}