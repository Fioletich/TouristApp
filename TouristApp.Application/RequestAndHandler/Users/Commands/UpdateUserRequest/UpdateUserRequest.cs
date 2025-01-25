using MediatR;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;

public record UpdateUserRequest(Guid UserId, Guid? RoleId, string? Login, string? Password, string? City) : IRequest;