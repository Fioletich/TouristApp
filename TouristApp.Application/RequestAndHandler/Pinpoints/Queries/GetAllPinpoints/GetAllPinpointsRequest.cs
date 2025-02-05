using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;

public record GetAllPinpointsRequest : IRequest<IEnumerable<Pinpoint>>;