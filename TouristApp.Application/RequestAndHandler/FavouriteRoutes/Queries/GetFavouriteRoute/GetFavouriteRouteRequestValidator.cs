using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetFavouriteRoute;

public class GetFavouriteRouteRequestValidator : AbstractValidator<GetFavouriteRouteRequest> {
    public GetFavouriteRouteRequestValidator() {
        RuleFor(r => r.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.UserId)
            .NotEqual(Guid.Empty);
    }
}