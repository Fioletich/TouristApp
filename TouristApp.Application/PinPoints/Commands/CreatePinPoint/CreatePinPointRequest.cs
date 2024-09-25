using MediatR;

namespace TouristApp.Application.PinPoints.Commands.CreatePinPoint;

public class CreatePinPointRequest : IRequest<Guid> {
    public string Name { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}