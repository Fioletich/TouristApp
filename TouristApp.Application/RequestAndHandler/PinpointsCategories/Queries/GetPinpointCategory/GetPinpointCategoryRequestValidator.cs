using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetPinpointCategory;

public class GetPinpointCategoryRequestValidator : AbstractValidator<GetPinpointCategoryRequest>{
    public GetPinpointCategoryRequestValidator() {
        RuleFor(r => r.PinpointId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.CategoryOfPinpointId)
            .NotEqual(Guid.Empty);
    }
}