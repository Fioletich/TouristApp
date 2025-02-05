namespace TouristApp.Domain.Models.Pinpoint;

public class PinpointDto {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? AudioUrl { get; set; }
    public decimal XCoordinate { get; set; }
    public decimal YCoordinate { get; set; }
}