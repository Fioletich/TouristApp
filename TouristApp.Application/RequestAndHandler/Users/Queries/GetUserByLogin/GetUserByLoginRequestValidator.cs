using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUserByLogin;

public class GetUserByLoginRequestValidator : AbstractValidator<GetUserByLoginRequest>{
    public GetUserByLoginRequestValidator() {
        RuleFor(u => u.Login)
            .NotEmpty()
            .NotNull()
            .MaximumLength(255);
    }
}