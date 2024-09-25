using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Routes.Queries.GetRoute;

public class GetRouteRequest : IRequest<Route>{
    public Guid Id { get; set; }
}