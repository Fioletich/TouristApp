using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest> {
    public UpdateCategoryRequestValidator() {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);

        RuleFor(c => c.Name)
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(c => c.Description)
            .NotEqual(string.Empty)
            .MaximumLength(255);
    }
}