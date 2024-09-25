using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("touristroutes")]
public class TouristRoute {
    [Column("id")] public Guid Id { get; set; }
    [Column("route_id")] public Guid RouteId { get; set; }
    [Column("pinpoint_id")] public Guid PinPointId { get; set; }
}