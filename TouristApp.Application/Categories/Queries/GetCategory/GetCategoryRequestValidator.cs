using FluentValidation;

namespace TouristApp.Application.Categories.Queries.GetCategory;

public class GetCategoryRequestValidator : AbstractValidator<GetCategoryRequest> {
    public GetCategoryRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}