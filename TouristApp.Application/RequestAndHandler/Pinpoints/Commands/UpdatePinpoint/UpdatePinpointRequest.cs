using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;

public record UpdatePinpointRequest(Guid Id, string? Name, string? Description, string? AudioUrl, decimal XCoordinate,
    decimal YCoordinate) : IRequest;