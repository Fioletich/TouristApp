using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.DeleteRouteCategory;

public class DeleteRouteCategoryRequestValidator : AbstractValidator<DeleteRouteCategoryRequest> {
    public DeleteRouteCategoryRequestValidator() {
        RuleFor(r => r.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.RouteCategoryId)
            .NotEqual(Guid.Empty);
    }
}