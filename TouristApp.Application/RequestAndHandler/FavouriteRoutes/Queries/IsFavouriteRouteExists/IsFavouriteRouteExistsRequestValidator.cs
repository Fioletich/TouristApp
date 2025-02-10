using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.IsFavouriteRouteExists;

public class IsFavouriteRouteExistsRequestValidator : AbstractValidator<IsFavouriteRouteExistsRequest> {
    public IsFavouriteRouteExistsRequestValidator() {
        RuleFor(fr => fr.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(fr => fr.UserId)
            .NotEqual(Guid.Empty);
    }
}