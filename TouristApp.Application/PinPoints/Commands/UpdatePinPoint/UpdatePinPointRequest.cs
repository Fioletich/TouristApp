using MediatR;

namespace TouristApp.Application.PinPoints.Commands.UpdatePinPoint;

public class UpdatePinPointRequest : IRequest<Unit>{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}