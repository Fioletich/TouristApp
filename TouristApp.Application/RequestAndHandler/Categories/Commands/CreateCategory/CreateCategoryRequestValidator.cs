using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest> {
    public CreateCategoryRequestValidator() {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);
    }
}