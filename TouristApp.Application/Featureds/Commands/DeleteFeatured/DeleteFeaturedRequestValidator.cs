using FluentValidation;

namespace TouristApp.Application.Featureds.Commands.DeleteFeatured;

public class DeleteFeaturedRequestValidator : AbstractValidator<DeleteFeaturedRequest> {
    public DeleteFeaturedRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}