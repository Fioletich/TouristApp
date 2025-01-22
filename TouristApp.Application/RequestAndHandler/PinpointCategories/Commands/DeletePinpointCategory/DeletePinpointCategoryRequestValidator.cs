using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequestValidator : AbstractValidator<DeletePinpointCategoryRequest> {
    public DeletePinpointCategoryRequestValidator() {
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty);
    }
}