using FluentValidation;

namespace TouristApp.Application.PinPoints.Commands.DeletePinPoint;

public class DeletePinPointRequestValidator : AbstractValidator<DeletePinPointRequest> {
    public DeletePinPointRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}