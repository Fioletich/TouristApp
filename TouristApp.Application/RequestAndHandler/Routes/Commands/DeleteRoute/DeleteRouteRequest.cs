using MediatR;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;

public record DeleteRouteRequest(Guid Id) : IRequest;