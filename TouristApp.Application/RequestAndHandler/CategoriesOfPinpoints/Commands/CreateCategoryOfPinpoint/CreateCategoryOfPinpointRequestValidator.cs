using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.CreateCategoryOfPinpoint;

public class CreateCategoryOfPinpointRequestValidator : AbstractValidator<CreateCategoryOfPinpointRequest> {
    public CreateCategoryOfPinpointRequestValidator() {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(50);

        RuleFor(request => request.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(1000);
    }
}