using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinPoints.Queries.GetPinPoint;

public class GetPinPointRequest : IRequest<PinPoint> {
    public Guid Id { get; set; }
}