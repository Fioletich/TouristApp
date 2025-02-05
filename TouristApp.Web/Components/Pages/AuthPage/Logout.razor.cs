using Microsoft.AspNetCore.Components;
using TouristApp.Web.Identity;

namespace TouristApp.Web.Components.Pages.AuthPage;

public partial class Logout : ComponentBase {
    async protected override Task OnInitializedAsync() {
        await ((CustomAuthStateProvider)AuthStateProvider).LogoutUser();

        NavManager.NavigateTo($"{NavManager.BaseUri}Login");
    }
}