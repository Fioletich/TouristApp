using FluentValidation;
using TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequestValidator : AbstractValidator<DeleteRouteRequest> {
    public DeleteTouristRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}