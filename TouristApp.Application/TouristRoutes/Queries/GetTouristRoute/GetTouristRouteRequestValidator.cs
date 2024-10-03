using FluentValidation;

namespace TouristApp.Application.TouristRoutes.Queries.GetTouristRoute;

public class GetTouristRouteRequestValidator : AbstractValidator<GetTouristRouteRequest> {
    public GetTouristRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}