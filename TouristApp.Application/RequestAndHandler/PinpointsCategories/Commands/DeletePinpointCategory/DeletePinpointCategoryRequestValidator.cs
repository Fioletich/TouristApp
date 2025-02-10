using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequestValidator : AbstractValidator<DeletePinpointCategoryRequest> {
    public DeletePinpointCategoryRequestValidator() {
        RuleFor(r => r.PinpointId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.CategoryOfPinpointId)
            .NotEqual(Guid.Empty);
    }
}