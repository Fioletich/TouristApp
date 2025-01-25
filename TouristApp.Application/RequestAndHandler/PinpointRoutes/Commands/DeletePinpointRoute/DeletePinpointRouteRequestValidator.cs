using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;

public class DeletePinpointRouteRequestValidator : AbstractValidator<DeletePinpointRouteRequest>{
    public DeletePinpointRouteRequestValidator() {
        RuleFor(pr => pr.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(pr => pr.PinpointId)
            .NotEqual(Guid.Empty);
    }
}