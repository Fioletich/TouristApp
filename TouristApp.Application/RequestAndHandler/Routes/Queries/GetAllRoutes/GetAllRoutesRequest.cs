using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;

public class GetAllRoutesRequest : IRequest<IEnumerable<Route>>{
    
}