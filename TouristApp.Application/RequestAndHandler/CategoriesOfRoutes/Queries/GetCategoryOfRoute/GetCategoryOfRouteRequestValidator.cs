using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;

public class GetCategoryOfRouteRequestValidator : AbstractValidator<GetCategoryOfRouteRequest> {
    public GetCategoryOfRouteRequestValidator() {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty);
    }
}