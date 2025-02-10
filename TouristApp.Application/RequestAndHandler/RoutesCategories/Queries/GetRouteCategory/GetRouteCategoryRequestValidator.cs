using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetRouteCategory;

public class GetRouteCategoryRequestValidator : AbstractValidator<GetRouteCategoryRequest> {
    public GetRouteCategoryRequestValidator() {
        RuleFor(rc => rc.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(rc => rc.CategoryOfRouteId)
            .NotEqual(Guid.Empty);
    }
}