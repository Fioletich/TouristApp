using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;

public record CreatePinpointRequest(Guid UserId, string Name, string Description, string? AudioUrl, decimal XCoordinate,
    decimal YCoordinate) : IRequest<Guid>;