using FluentValidation;

namespace TouristApp.Application.Featureds.Commands.CreateFeatured;

public class CreateFeaturedRequestValidator : AbstractValidator<CreateFeaturedRequest> {
    public CreateFeaturedRequestValidator() {
        RuleFor(request => request.TouristRouteId)
            .NotEqual(Guid.Empty);

        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);

    }
}