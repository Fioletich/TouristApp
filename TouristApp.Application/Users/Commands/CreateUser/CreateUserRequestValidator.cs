using FluentValidation;

namespace TouristApp.Application.Users.Commands.CreateUser;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest> {
    public CreateUserRequestValidator() {
        RuleFor(request => request.Login)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Password)
            .NotNull()
            .NotEqual(string.Empty)
            .MaximumLength(255);
    }
}