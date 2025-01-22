using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequestValidator : AbstractValidator<CreateTouristRouteRequest> {
    public CreateTouristRouteRequestValidator() {
        RuleFor(request => request.RouteId)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.PinPointId)
            .NotEqual(Guid.Empty);
    }
}