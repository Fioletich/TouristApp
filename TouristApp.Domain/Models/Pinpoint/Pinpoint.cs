using TouristApp.Domain.Abstractions;

namespace TouristApp.Domain.Models.Pinpoint;
public class Pinpoint : AuditableEntity {
    public Guid Id { get; private set; }
    public List<Route.Route> Routes { get; } = [];
    public string Name { get; set; }
    public string Description { get;  set; }
    public string? AudioUrl { get; set; }       
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }

    private Pinpoint() { }

    public static Pinpoint Create( string name, string description, string? audioUrl, decimal xCoordinate,
        decimal yCoordinate) {
        var pinpoint = new Pinpoint()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            AudioUrl = audioUrl,
            XCoordinate = xCoordinate,
            YCoordinate = yCoordinate,
        };
        
        pinpoint.Update();
        
        return pinpoint; 
    }
}