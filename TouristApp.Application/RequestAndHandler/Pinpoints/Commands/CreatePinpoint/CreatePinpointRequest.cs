using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;

public class CreatePinpointRequest : IRequest<Guid> {
    public string Name { get; set; }
    public string Description { get; set; }
    public string? AudioUrl { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}