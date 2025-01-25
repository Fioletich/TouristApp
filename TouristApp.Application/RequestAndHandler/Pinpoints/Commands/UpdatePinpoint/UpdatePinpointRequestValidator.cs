using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;

public class UpdatePinpointRequestValidator : AbstractValidator<UpdatePinpointRequest> {
    public UpdatePinpointRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
        
        RuleFor(request => request.Name)
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Description)
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.AudioUrl)
            .MaximumLength(255);

        RuleFor(request => request.XCoordinate)
            .GreaterThan(-180m)
            .LessThan(180m);
        
        RuleFor(request => request.YCoordinate)
            .GreaterThan(-85m)
            .LessThan(85m);
    }
}