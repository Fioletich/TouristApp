using System.ComponentModel.DataAnnotations;
using TouristApp.Domain.CustomAttributes;

namespace TouristApp.Domain.Models.Pinpoint;

public class PinpointDto {
    public Guid Id { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Название достопримечательности необходимо заполнить.")]
    public string Name { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false, ErrorMessage = "Описание достопримечательности необходимо заполнить.")]
    public string Description { get; set; } = string.Empty;
    [Url(ErrorMessage = "Введите корректный Url адрес.")]
    public string? AudioUrl { get; set; }
    [Required(ErrorMessage = "Координату по оси Х необходимо заполнить.")]
    [NotZero(ErrorMessage = "Координата X не может быть равна нулю.")]
    public decimal XCoordinate { get; set; }
    [Required(ErrorMessage = "Координату по оси Х необходимо заполнить.")]
    [NotZero(ErrorMessage = "Координата Y не может быть равна нулю.")]
    public decimal YCoordinate { get; set; }
}