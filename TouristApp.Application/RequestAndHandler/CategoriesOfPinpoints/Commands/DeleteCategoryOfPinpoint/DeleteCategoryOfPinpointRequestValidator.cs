using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.DeleteCategoryOfPinpoint;

public class DeleteCategoryOfPinpointRequestValidator : AbstractValidator<DeleteCategoryOfPinpointRequest> {
    public DeleteCategoryOfPinpointRequestValidator() {
        RuleFor(request => request.Id)
            .NotEqual(Guid.Empty);
    }
}