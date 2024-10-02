using MediatR;

namespace TouristApp.Application.Users.Commands.UserCreate;

public class CreateUserRequest : IRequest<Guid> {
    public string? Login { get; set; }
    public string? Password { get; set; }
}