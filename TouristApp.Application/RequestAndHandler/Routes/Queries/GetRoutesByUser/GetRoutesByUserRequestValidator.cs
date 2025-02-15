using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoutesByUser;

public class GetRoutesByUserRequestValidator : AbstractValidator<GetRoutesByUserRequest>{
    public GetRoutesByUserRequestValidator() {
        RuleFor(r => r.UserId)
            .NotEqual(Guid.Empty);
    }
}