using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;

public class DeletePinpointRequestValidator : AbstractValidator<DeletePinpointRequest> {
    public DeletePinpointRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}