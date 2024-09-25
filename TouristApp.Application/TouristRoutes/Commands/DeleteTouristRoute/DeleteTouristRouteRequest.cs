using MediatR;

namespace TouristApp.Application.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequest : IRequest {
    public Guid Id { get; set; }
}