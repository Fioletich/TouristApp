using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;

public class DeletePinpointRequest : IRequest {
    public Guid Id { get; set; }
}