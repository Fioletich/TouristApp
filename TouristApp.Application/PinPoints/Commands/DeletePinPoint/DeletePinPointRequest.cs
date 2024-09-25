using MediatR;

namespace TouristApp.Application.PinPoints.Commands.DeletePinPoint;

public class DeletePinPointRequest : IRequest {
    public Guid Id { get; set; }
}