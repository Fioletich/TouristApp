using MediatR;

namespace TouristApp.Application.Users.Commands.CreateUser;

public class CreateUserRequest : IRequest<Guid> {
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Bio { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
}