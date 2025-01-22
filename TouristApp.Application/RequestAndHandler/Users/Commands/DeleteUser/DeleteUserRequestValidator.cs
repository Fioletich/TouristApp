using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;

public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest> {
    public DeleteUserRequestValidator() {
        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);
    }
}