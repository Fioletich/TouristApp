using FluentValidation;

namespace TouristApp.Application.PinpointsCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequestValidator : AbstractValidator<DeletePinpointCategoryRequest> {
    public DeletePinpointCategoryRequestValidator() {
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty);
    }
}