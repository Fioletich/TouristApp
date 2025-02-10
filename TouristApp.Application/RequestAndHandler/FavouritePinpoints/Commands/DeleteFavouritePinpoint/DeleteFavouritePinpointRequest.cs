using MediatR;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.DeleteFavouritePinpoint;

public record DeleteFavouritePinpointRequest(Guid UserId, Guid PinpointId) : IRequest;