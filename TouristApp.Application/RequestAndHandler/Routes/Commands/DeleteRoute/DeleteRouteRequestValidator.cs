using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;

public class DeleteRouteRequestValidator : AbstractValidator<DeleteRouteRequest> {
    public DeleteRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}