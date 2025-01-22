using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Queries.GetTouristRoute;

public class GetTouristRouteRequestValidator : AbstractValidator<GetTouristRouteRequest> {
    public GetTouristRouteRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}