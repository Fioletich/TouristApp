using FluentValidation;

namespace TouristApp.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest> {
    public UpdateCategoryRequestValidator() {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);

        RuleFor(c => c.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(c => c.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);
    }
}