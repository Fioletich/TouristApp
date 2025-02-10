using MediatR;
using TouristApp.Domain.Models.FavouritePinpoint;

namespace TouristApp.Application.RequestAndHandler.FavouritePinpoints.Queries.GetAllFavouritePinpoints;

public record GetAllFavouritePinpointsRequest : IRequest<IEnumerable<FavouritePinpoint>>;