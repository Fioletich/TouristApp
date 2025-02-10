using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.UpdateCategoryOfPinpoint;

public class UpdateCategoryOfPinpointRequestValidator : AbstractValidator<UpdateCategoryOfPinpointRequest> {
    public UpdateCategoryOfPinpointRequestValidator() {
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