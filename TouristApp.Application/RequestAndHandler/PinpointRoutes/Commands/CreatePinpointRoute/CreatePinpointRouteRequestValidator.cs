using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.CreatePinpointRoute;

public class CreatePinpointRouteRequestValidator : AbstractValidator<CreatePinpointRouteRequest>{
    public CreatePinpointRouteRequestValidator() {
        RuleFor(pr => pr.PinpointId)
            .NotEqual(Guid.Empty);
        
        RuleFor(pr => pr.RouteId)
            .NotEqual(Guid.Empty);
    }
}