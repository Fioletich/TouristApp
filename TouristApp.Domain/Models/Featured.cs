using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("Featureds")]
public class Featured {
    [Column("Id")] public Guid Id { get; set; }
    [Column("TouristRouteId")] public Guid TouristRouteId { get; set; }
    [Column("UserId")] public Guid UserId { get; set; }
}