using MediatR;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Commands.CreateFavouritePinpoint;

public record CreateFavouritePinpointRequest(Guid UserId, Guid PinpointId) : IRequest;