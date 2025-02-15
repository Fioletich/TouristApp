using MediatR;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetRoleByName;

public record GetRoleByNameRequest(string Name) : IRequest<Role>;