using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.DeleteCategoryOfRoute;

public class DeleteCategoryOfRouteRequestValidator : AbstractValidator<DeleteCategoryOfRouteRequest>{
    public DeleteCategoryOfRouteRequestValidator() {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty);
    }
}