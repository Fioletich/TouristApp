using FluentValidation;

namespace TouristApp.Application.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest> {
    public UpdateUserRequestValidator() {
        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);

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