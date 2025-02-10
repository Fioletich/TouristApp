using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.CreateFavouriteRoute;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.DeleteFavouriteRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;
using TouristApp.Domain.Models.FavouriteRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Components.Pages.Routes.RoutesComponents;

public partial class RouteCard : ComponentBase {
    [Parameter] [EditorRequired] public RouteDto Route { get; set; } = default!;

    [Parameter] [EditorRequired] public Action OnRouteDescription { get; set; } = default!;

    [Parameter] [EditorRequired] public Action OnRoutePinpoints { get; set; } = default!;

    [Parameter] [EditorRequired] public EventCallback<RouteDto> OnDeleteRouteEventCallback { get; set; }
    [Parameter] [EditorRequired] public EventCallback<RouteDto> OnDeleteFavouriteRouteEventCallback { get; set; }
    [Parameter] [EditorRequired] public EventCallback<FavouriteRouteDto> OnAddFavouriteRouteEventCallback { get; set; }
    [Parameter] [EditorRequired] public Guid UserId { get; set; }

    [Parameter] [EditorRequired] public IEnumerable<FavouriteRouteDto> FavouriteRoutes { get; set; } = [];

    [Parameter] public bool IsUserCreated { get; set; } = true;

    private ConfirmDialog _deleteRouteConfirmDialog = default!;

    private List<ToastMessage> _messages = new List<ToastMessage>();

    private bool IsRouteFavourite => FavouriteRoutes.Any(fr => fr.UserId == UserId && fr.RouteId == Route.Id);

    private async Task<bool> ShowDeleteRouteConfirmDialog() {
        return await _deleteRouteConfirmDialog.ShowAsync(
            title: "Вы уверены что хотите удалить этот маршрут?",
            message1: "Это действие удалит маршрут из базы данных безвовозратно.",
            message2: "Хотите продолжить?");
    }

    private async Task OnRouteDeleteClick() {
        if (await ShowDeleteRouteConfirmDialog())
        {
            foreach (var favouriteRoute in FavouriteRoutes)
            {
                if (favouriteRoute.RouteId == Route.Id)
                {
                    await Mediator
                        .Send(new DeleteFavouriteRouteRequest(favouriteRoute.UserId, favouriteRoute.RouteId));
                }
            }
            
            await Mediator.Send(new DeleteRouteRequest(Route.Id));
            
            await OnDeleteRouteEventCallback.InvokeAsync(Route);

            ShowToast($"Маршрут {Route.Name} успешно удален.", ToastType.Secondary);
        }
        else
        {
            ShowToast($"Удаление маршрута {Route.Name} прервано.", ToastType.Danger);
        }
    }

    private void ShowToast(string message, ToastType type = ToastType.Info) {
        _messages.Add(GetToastMessage(message, type));
    }

    private ToastMessage GetToastMessage(string message, ToastType type = ToastType.Info) {
        return new ToastMessage()
        {
            Type = type,
            HelpText = $"{DateTime.Now}",
            Message = message
        };
    }

    private async Task OnFavouriteRouteAddClick() {
        await Mediator.Send(new CreateFavouriteRouteRequest(UserId, Route.Id));
        
        var favouriteRoute = new FavouriteRouteDto()
        {
            UserId = UserId,
            RouteId = Route.Id
        };
        
        await OnAddFavouriteRouteEventCallback.InvokeAsync(favouriteRoute);
    }

    private async Task OnFavouriteRouteDeleteClick() {
        await Mediator.Send(new DeleteFavouriteRouteRequest(UserId, Route.Id));
        await OnDeleteFavouriteRouteEventCallback.InvokeAsync(Route);
    }
}