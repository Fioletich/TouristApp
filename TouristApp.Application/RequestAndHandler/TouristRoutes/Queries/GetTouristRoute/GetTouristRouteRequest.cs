using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Queries.GetTouristRoute;

public class GetTouristRouteRequest : IRequest<TouristRoute> {
    public Guid Id { get; set; }
}