using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.CreateRouteCategory;

public class CreateRouteCategoryRequestValidator : AbstractValidator<CreateRouteCategoryRequest> {
    public CreateRouteCategoryRequestValidator() {
        RuleFor(r => r.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.RouteId)
            .NotEqual(Guid.Empty);
    }
}