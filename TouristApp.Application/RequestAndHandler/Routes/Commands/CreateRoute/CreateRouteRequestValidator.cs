using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;

public class CreateRouteRequestValidator : AbstractValidator<CreateRouteRequest> {
    public CreateRouteRequestValidator() {
        RuleFor(r => r.UserId)
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