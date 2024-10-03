using MediatR;

namespace TouristApp.Application.Users.Commands.DeleteUser;

public class DeleteUserRequest : IRequest {
    public Guid UserId { get; set; }
}