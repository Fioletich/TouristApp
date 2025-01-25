using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest> {
    public UpdateUserRequestValidator() {
        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);
        
        RuleFor(request => request.RoleId)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.Login)
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.Password)
            .NotEqual(string.Empty)
            .MaximumLength(255);

        RuleFor(request => request.City)
            .MaximumLength(255);
    }
}