namespace TouristApp.Domain.Models.Route;

public class RouteDTO {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}