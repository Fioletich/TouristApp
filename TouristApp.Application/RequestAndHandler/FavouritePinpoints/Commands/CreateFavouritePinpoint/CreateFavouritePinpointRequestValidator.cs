using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.CreateFavouritePinpoint;

public class CreateFavouritePinpointRequestValidator : AbstractValidator<CreateFavouritePinpointRequest>{
    public CreateFavouritePinpointRequestValidator() {
        RuleFor(r => r.UserId)
            .NotEqual(Guid.Empty);
        
        RuleFor(r => r.PinpointId)
            .NotEqual(Guid.Empty);
    }
}