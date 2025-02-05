using System.Text.Json.Serialization;

namespace TouristApp.Domain.Models.Pinpoint;

public class JsPinpoint {
    [JsonPropertyName("coords")]
    public decimal[]? Coords { get; set; }
    [JsonPropertyName("info")]
    public string Info { get; set; } = string.Empty;
    [JsonPropertyName("images")]
    public string[]? Images { get; set; }
}