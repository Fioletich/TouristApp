using FluentValidation;

namespace TouristApp.Application.Featureds.Queries.GetFeatured;

public class GetFeaturedRequestValidator : AbstractValidator<GetFeaturedRequest> {
    public GetFeaturedRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}