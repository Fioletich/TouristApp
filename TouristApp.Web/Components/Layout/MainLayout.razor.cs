using Microsoft.AspNetCore.Components;

namespace TouristApp.Web.Components.Layout;

public partial class MainLayout : LayoutComponentBase {
    private void OnLogoutClick() {
        NavManager.NavigateTo($"{NavManager.BaseUri}Logout", true);
    }

    private void OnLoginClick() {
        NavManager.NavigateTo($"{NavManager.BaseUri}AuthPage");
    }
}