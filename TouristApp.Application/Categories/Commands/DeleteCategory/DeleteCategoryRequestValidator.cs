using FluentValidation;

namespace TouristApp.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryRequestValidator : AbstractValidator<DeleteCategoryRequest> {
    public DeleteCategoryRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}