using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.CreateCategoryOfRoute;

public class CreateCategoryOfRouteRequestValidator : AbstractValidator<CreateCategoryOfRouteRequest> {
    public CreateCategoryOfRouteRequestValidator() {
        RuleFor(cr => cr.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
        
        RuleFor(cr => cr.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(1000);
    }
}