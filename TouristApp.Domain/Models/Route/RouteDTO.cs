using System.ComponentModel.DataAnnotations;

namespace TouristApp.Domain.Models.Route;

public class RouteDto {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Необходимо ввести название маршрута.")]
    public string Name { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false, ErrorMessage = "Необходимо ввести описание маршрута.")]
    public string Description { get; set; } = string.Empty;
}