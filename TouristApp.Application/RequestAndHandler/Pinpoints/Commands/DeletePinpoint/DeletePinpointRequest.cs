using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;

public record DeletePinpointRequest(Guid Id) : IRequest;