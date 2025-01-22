using MediatR;

namespace TouristApp.Application.RequestAndHandler.TouristRoutes.Commands.DeleteTouristRoute;

public class DeleteTouristRouteRequest : IRequest {
    public Guid Id { get; set; }
}