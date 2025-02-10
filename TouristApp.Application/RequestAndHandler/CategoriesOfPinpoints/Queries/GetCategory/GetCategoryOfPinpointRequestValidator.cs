using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetCategory;

public class GetCategoryOfPinpointRequestValidator : AbstractValidator<GetCategoryOfPinpointRequest> {
    public GetCategoryOfPinpointRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}