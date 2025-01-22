using MediatR;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;

public class DeleteRouteRequest  : IRequest{
    public Guid Id { get; set; }
}