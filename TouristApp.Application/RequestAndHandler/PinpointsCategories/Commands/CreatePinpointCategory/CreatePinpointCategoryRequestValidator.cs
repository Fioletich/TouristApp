using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequestValidator : AbstractValidator<CreatePinpointCategoryRequest>{
    public CreatePinpointCategoryRequestValidator() {
        RuleFor(r => r.PinpointId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.CategoryOfPinpointId)
            .NotEqual(Guid.Empty);
    }
}