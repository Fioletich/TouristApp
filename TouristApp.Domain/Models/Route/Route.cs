using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.Route;

public class Route : AuditableEntity {
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public User.User User { get; private set; }
    public List<Pinpoint.Pinpoint> Pinpoints { get; } = [];    
    public string Name { get; set; }
    public string Description { get; set; }

    private Route() { }

    public static Route Create(User.User user, string name, string description) {
        var route = new Route()
        {
            Id = Guid.NewGuid(),
            User = user,
            UserId = user.Id,
            Name = name,
            Description = description
        };
        
        route.Update();

        return route;
    }
}