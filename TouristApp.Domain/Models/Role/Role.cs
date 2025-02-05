using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.Role;

public class Role : AuditableEntity{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public List<User.User> Users { get; } = [];
    
    private Role() { }

    public static Role Create(string name) {
        var role = new Role() {
            Id = Guid.NewGuid(),
            Name = name
        };
        
        role.Update();

        return role;
    }
}