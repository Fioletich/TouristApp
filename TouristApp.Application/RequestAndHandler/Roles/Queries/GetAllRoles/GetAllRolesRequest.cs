using MediatR;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetAllRoles;

public record GetAllRolesRequest() : IRequest<IEnumerable<Role>>;