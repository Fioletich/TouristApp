namespace TouristApp.Domain.Models.Pinpoint;

public class PinpointDTO {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? AudioUrl { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}