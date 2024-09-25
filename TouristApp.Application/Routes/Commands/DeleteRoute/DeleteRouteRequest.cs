using MediatR;

namespace TouristApp.Application.Routes.Commands.DeleteRoute;

public class DeleteRouteRequest  : IRequest{
    public Guid Id { get; set; }
}