using MediatR;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;

public class UpdatePinpointRequest : IRequest<Unit>{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? AudioUrl { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}