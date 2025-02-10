using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.DeleteFavouritePinpoint;

public class DeleteFavouritePinpointRequestValidator : AbstractValidator<DeleteFavouritePinpointRequest> {
    public DeleteFavouritePinpointRequestValidator() {
        RuleFor(r => r.UserId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.PinpointId)
            .NotEqual(Guid.Empty);
    }
}