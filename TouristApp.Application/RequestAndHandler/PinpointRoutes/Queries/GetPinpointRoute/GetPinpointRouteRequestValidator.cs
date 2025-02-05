using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;

public class GetPinpointRouteRequestValidator : AbstractValidator<GetPinpointRouteRequest> {
    public GetPinpointRouteRequestValidator() {
        RuleFor(pr => pr.RouteId)
            .NotEqual(Guid.Empty);
        
        RuleFor(pr => pr.PinpointId)
            .NotEqual(Guid.Empty);
    }
}