using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;

public class CreatePinpointRequestValidator : AbstractValidator<CreatePinpointRequest> {
    public CreatePinpointRequestValidator() {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(50);

        RuleFor(request => request.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(1000);

        RuleFor(request => request.AudioUrl)
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