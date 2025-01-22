using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;

public class GetAllPinpointsRequest : IRequest<IEnumerable<Pinpoint>> {
    
}