using MediatR;

namespace TouristApp.Application.Users.Commands.UpdateUserRequest;

public class UpdateUserRequest : IRequest {
    public Guid UserId { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Bio { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
}