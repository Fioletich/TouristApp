using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.Pinpoint;
public class Pinpoint : AuditableEntity {
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public User.User User { get; set; }
    public List<Route.Route> Routes { get; } = [];
    public string Name { get; set; }
    public string Description { get;  set; }
    public string? AudioUrl { get; set; }       
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }

    private Pinpoint() { }

    public static Pinpoint Create(User.User user, string name, string description, string? audioUrl, decimal xCoordinate,
        decimal yCoordinate) {
        var pinpoint = new Pinpoint()
        {
            Id = Guid.NewGuid(),
            User = user,
            Name = name,
            Description = description,
            AudioUrl = audioUrl,
            XCoordinate = xCoordinate,
            YCoordinate = yCoordinate,
            UserId = user.Id
        };
        
        pinpoint.Update();
        
        return pinpoint; 
    }
}