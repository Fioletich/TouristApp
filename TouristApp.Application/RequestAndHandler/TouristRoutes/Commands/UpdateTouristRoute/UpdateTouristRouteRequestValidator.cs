using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.UpdateTouristRoute;

public class UpdateTouristRouteRequestValidator : AbstractValidator<UpdateTouristRouteRequest> {
    public UpdateTouristRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.RouteId)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.PinPointId)
            .NotEqual(Guid.Empty);
    }
}