namespace TouristApp.Domain.Models.Category;

public class CategoryOfPinpointDto {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}