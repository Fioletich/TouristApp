using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;

public record GetPinpointRequest(Guid Id) : IRequest<Pinpoint>;