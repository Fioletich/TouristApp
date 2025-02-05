using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.DeleteRole;

public class DeleteRoleRequestValidator : AbstractValidator<DeleteRoleRequest> {
    public DeleteRoleRequestValidator() {
        RuleFor(r => r.Id)
            .NotEqual(Guid.Empty);
    }
}