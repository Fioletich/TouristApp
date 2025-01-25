using MediatR;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.DeleteRole;

public record DeleteRoleRequest(Guid Id) : IRequest;