using FluentValidation;
using TouristApp.Application.Routes.Commands.DeleteRoute;

namespace TouristApp.Application.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequestValidator : AbstractValidator<DeleteRouteRequest> {
    public DeleteTouristRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}