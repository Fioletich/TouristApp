using MediatR;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.CreateRole;

public record CreateRoleRequest(string Name) : IRequest<Guid>;