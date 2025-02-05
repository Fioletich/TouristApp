using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.DeleteFavouriteRoute;

public class DeleteFavouriteRouteRequestValidator : AbstractValidator<DeleteFavouriteRouteRequest> {
    public DeleteFavouriteRouteRequestValidator() {
        RuleFor(request => request.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(request => request.RouteId)
            .NotEqual(Guid.Empty);
    }
}