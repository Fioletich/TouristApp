using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.CreateRole;

public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest> {
    public CreateRoleRequestValidator() {
        RuleFor(r => r.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}