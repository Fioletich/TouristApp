using FluentValidation;

namespace TouristApp.Application.Users.Queries.GetUser;

public class GetUserRequestValidator : AbstractValidator<GetUserRequest> {
    public GetUserRequestValidator() {
        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);
    }
}