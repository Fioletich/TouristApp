using MediatR;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetRole;

public record GetRoleRequest(Guid Id) : IRequest<Role>;