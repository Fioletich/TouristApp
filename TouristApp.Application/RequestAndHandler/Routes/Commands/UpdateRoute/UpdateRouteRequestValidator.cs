using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;

public class UpdateRouteRequestValidator : AbstractValidator<UpdateRouteRequest> {
    public UpdateRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.Name)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Description)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);
    }
}