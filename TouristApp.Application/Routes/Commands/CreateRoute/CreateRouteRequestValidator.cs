using FluentValidation;

namespace TouristApp.Application.Routes.Commands.CreateRoute;

public class CreateRouteRequestValidator : AbstractValidator<CreateRouteRequest> {
    public CreateRouteRequestValidator() {
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