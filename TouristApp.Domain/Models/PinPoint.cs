using System.ComponentModel.DataAnnotations.Schema;

namespace TouristApp.Domain.Models;

[Table("Pinpoints")]
public class PinPoint {
    [Column("Id")] public Guid Id { get; set; }
    [Column("CategoryId")] public Guid CategoryId { get; set; }
    [Column("Name")] public string? Name { get; set; }
    [Column("Description")] public string? Description { get; set; }
    [Column("XCoordinate")] public decimal XCoordinate { get; set; }
    [Column("YCoordinate")] public decimal YCoordinate { get; set; }
}