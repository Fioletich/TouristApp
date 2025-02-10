using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest> {
    public CreateUserRequestValidator() {
        RuleFor(request => request.Login)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(50);

        RuleFor(request => request.RoleId)
            .NotNull();

        RuleFor(request => request.Password)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.City)
            .MaximumLength(40);
    }
}