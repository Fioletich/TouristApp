using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;

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

        RuleFor(reqest => reqest.PhoneNumber)
            .MaximumLength(13);

        RuleFor(request => request.Bio)
            .MaximumLength(255);

        RuleFor(requst => requst.Country)
            .MaximumLength(255);

        RuleFor(request => request.City)
            .MaximumLength(255);
    }
}