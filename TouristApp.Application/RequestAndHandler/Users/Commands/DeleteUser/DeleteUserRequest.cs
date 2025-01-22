using MediatR;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;

public class DeleteUserRequest : IRequest {
    public Guid UserId { get; set; }
}