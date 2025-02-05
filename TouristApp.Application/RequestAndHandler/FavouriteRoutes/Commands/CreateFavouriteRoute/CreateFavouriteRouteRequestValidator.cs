using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.CreateFavouriteRoute;

public class CreateFavouriteRouteRequestValidator : AbstractValidator<CreateFavouriteRouteRequest> {
    public CreateFavouriteRouteRequestValidator() {
        RuleFor(fr => fr.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(fr => fr.UserId)
            .NotEqual(Guid.Empty);
    }
}