using FluentValidation;

namespace TouristApp.Application.PinPoints.Commands.CreatePinPoint;

public class CreatePinPointRequestValidator : AbstractValidator<CreatePinPointRequest> {
    public CreatePinPointRequestValidator() {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.XCoordinate)
            .NotEmpty()
            .GreaterThan(-180m)
            .LessThan(180m);
        
        RuleFor(request => request.YCoordinate)
            .NotEmpty()
            .GreaterThan(-85m)
            .LessThan(85m);
    }
}