using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("TouristRoutes")]
public class TouristRoute {
    [Column("Id")] public Guid Id { get; set; }
    [Column("RouteId")] public Guid RouteId { get; set; }
    [Column("PinpointId")] public Guid PinpointId { get; set; }
}