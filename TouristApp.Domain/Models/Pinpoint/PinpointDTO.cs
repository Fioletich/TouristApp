namespace TouristApp.Domain.Models.Pinpoint;

public record PinpointDTO(Guid Id, Guid UserId, string Name, string Description, string? AudioUrl);