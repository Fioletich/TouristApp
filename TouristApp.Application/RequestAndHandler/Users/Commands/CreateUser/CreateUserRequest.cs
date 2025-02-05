using MediatR;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;

public record CreateUserRequest(Guid RoleId, string Login, string Password, string? City) : IRequest<Guid>;