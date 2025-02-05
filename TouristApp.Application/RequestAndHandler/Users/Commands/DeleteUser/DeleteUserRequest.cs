using MediatR;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;

public record DeleteUserRequest(Guid UserId) : IRequest;