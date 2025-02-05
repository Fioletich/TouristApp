namespace TouristApp.Domain.Models.User;

public class UserDTO {
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string? City { get; set; }
}