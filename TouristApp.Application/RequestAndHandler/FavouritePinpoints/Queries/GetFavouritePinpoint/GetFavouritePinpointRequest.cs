using MediatR;
using TouristApp.Domain.Models.FavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetFavouritePinpoint;

public record GetFavouritePinpointRequest(Guid UserId, Guid PinpointId) : IRequest<FavouritePinpoint>;