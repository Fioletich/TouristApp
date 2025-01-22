using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestValidator : AbstractValidator<RequestAndHandler.Users.Commands.UpdateUserRequest.UpdateUserRequest> {
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