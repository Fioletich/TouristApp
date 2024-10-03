using FluentValidation;

namespace TouristApp.Application.Routes.Queries.GetRoute;

public class GetRouteValidator : AbstractValidator<GetRouteRequest> {
    public GetRouteValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}