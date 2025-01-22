using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;

public class GetPinpointRequest : IRequest<Pinpoint> {
    public Guid Id { get; set; }
}