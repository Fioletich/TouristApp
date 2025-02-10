using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.UpdateCategoryOfRoute;

public class UpdateCategoryOfRouteRequestValidator : AbstractValidator<UpdateCategoryOfRouteRequest>{
    public UpdateCategoryOfRouteRequestValidator() {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.Name)
            .MaximumLength(50);

        RuleFor(r => r.Description)
            .MaximumLength(1000);
    }
}