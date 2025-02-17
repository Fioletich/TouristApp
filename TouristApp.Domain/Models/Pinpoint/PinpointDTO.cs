using System.ComponentModel.DataAnnotations;

namespace TouristApp.Domain.Models.Pinpoint;

public class PinpointDto {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Название достопримечательности необходимо заполнить.")]
    public string Name { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false, ErrorMessage = "Описание достопримечательности необходимо заполнить.")]
    public string Description { get; set; } = string.Empty;
    public string? AudioUrl { get; set; }
    [Required(ErrorMessage = "Координату по оси Х необходимо заполнить.")]
    public decimal XCoordinate { get; set; }
    [Required(ErrorMessage = "Координату по оси Х необходимо заполнить.")]
    public decimal YCoordinate { get; set; }
}