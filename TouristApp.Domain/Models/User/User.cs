using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.User;

public class User : AuditableEntity {
    public Guid Id { get; private set; }
    public Guid RoleId { get; private set; }
    public Role.Role Role { get; set; }
    public List<Route.Route> Routes { get; private set; } = [];
    public string Login { get; set; }
    public string Password { get; set; }
    public string? City { get; set; }
    
    private User() { }

    public static User Create(Role.Role role, string login, string password, string? city) {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Role = role,
            Login = login,
            Password = password,
            City = city,
            RoleId = role.Id
        };
        
        user.Update();

        return user;
    }
}