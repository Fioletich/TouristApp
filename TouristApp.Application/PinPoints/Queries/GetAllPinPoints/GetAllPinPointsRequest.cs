using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinPoints.Queries.GetAllPinPoints;

public class GetAllPinPointsRequest : IRequest<IEnumerable<PinPoint>> {
    
}