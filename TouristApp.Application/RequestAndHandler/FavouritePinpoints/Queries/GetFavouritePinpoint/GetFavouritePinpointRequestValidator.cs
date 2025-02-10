using FluentValidation;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetFavouritePinpoint;

public class GetFavouritePinpointRequestValidator : AbstractValidator<GetFavouritePinpointRequest> {
    public GetFavouritePinpointRequestValidator() {
        RuleFor(request => request.PinpointId)
            .NotEqual(Guid.Empty);
        
        RuleFor(request => request.UserId)
            .NotEqual(Guid.Empty);
    }
}